using System;
using System.Threading.Tasks;
using Kasp.Core.Tests;
using Kasp.Db.Extensions;
using Kasp.Db.Tests.Data.Repositories;
using Kasp.Db.Tests.Models.NewsModel;
using Microsoft.EntityFrameworkCore.DynamicLinq;
using Microsoft.Extensions.DependencyInjection;
using Xunit;
using Xunit.Abstractions;

namespace Kasp.Db.Tests.Tests {
	public class HelperTests : IClassFixture<KWebAppFactory<StartupDb>> {
		public HelperTests(KWebAppFactory<StartupDb> factory, ITestOutputHelper output) {
			factory.CreateDefaultClient();
			_output = output;
			_newsRepository = factory.Server.Host.Services.GetService<NewsRepository>();
		}

		private readonly News _model = new News {
			Title = "this is title", Content = "this is body"
		};

		private readonly ITestOutputHelper _output;
		private readonly NewsRepository _newsRepository;

		[Fact]
		public async Task ModelTest() {
			await _newsRepository.AddAsync(_model);
			await _newsRepository.SaveAsync();

			Assert.True(_model.Id > 0);
		}

		[Fact]
		public async Task CreateTimeTest() {
			await _newsRepository.AddAsync(_model);
			await _newsRepository.SaveAsync();

			Assert.True(_model.CreateTime > DateTime.UtcNow.AddMinutes(-1));
		}

		[Fact]
		public async Task UpdateTimeBeforeChange() {
			await _newsRepository.AddAsync(_model);
			await _newsRepository.SaveAsync();

			Assert.Null(_model.UpdateTime);
		}

		[Fact]
		public async Task UpdateTimeAfterChange() {
			await _newsRepository.AddAsync(_model);
			await _newsRepository.SaveAsync();
			
			_model.Title = "new title";

			_newsRepository.Update(_model);
			await _newsRepository.SaveAsync();

			Assert.NotNull(_model.UpdateTime);
			Assert.True(_model.UpdateTime > DateTime.UtcNow.AddMinutes(-1));
		}
	}
}