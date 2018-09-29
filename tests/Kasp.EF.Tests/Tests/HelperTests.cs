using System;
using System.Threading.Tasks;
using Kasp.Core.Tests;
using Kasp.EF.Extensions;
using Kasp.EF.Tests.Data.Repositories;
using Kasp.EF.Tests.Models.NewsModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Xunit;
using Xunit.Abstractions;

namespace Kasp.EF.Tests.Tests {
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
		public async Task UpdateTimeBeforeChangeTest() {
			await _newsRepository.AddAsync(_model);
			await _newsRepository.SaveAsync();

			Assert.Null(_model.UpdateTime);
		}

		[Fact]
		public async Task UpdateTimeAfterChangeTest() {
			await _newsRepository.AddAsync(_model);
			await _newsRepository.SaveAsync();

			_model.Title = "new title";

			_newsRepository.Update(_model);
			await _newsRepository.SaveAsync();

			Assert.NotNull(_model.UpdateTime);
			Assert.True(_model.UpdateTime > DateTime.UtcNow.AddMinutes(-1));
		}

		[Fact]
		public async Task EnableTrue() {
			var model = _model;
			model.Enable = true;
			await _newsRepository.AddAsync(model);
			await _newsRepository.SaveAsync();

			_output.WriteLine(model.ToString());
			var item = await _newsRepository.BaseQuery.EnableFilter().FirstOrDefaultAsync(x => x.Id == model.Id);

			Assert.NotNull(item);
		}

		[Fact]
		public async Task EnableFalse() {
			var model = _model;
			model.Enable = false;
			await _newsRepository.AddAsync(model);
			await _newsRepository.SaveAsync();

			_output.WriteLine(model.ToString());
			var item = await _newsRepository.BaseQuery.EnableFilter().FirstOrDefaultAsync(x => x.Id == model.Id);

			Assert.Null(item);
		}

		[Fact]
		public async Task BeforePublishTime() {
			var model = _model;
			model.PublishTime = DateTime.UtcNow.AddDays(1);
			await _newsRepository.AddAsync(model);
			await _newsRepository.SaveAsync();

			var item = await _newsRepository.BaseQuery.PublishTimeFilter().FirstOrDefaultAsync(x => x.Id == model.Id);

			Assert.Null(item);
		}

		[Fact]
		public async Task AfterPublishTime() {
			var model = _model;
			model.PublishTime = DateTime.UtcNow.AddDays(-1);
			await _newsRepository.AddAsync(model);
			await _newsRepository.SaveAsync();

			var item = await _newsRepository.BaseQuery.PublishTimeFilter().FirstOrDefaultAsync(x => x.Id == model.Id);

			Assert.NotNull(item);
		}
	}
}