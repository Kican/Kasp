using System;
using System.Threading.Tasks;
using Kasp.Data.EF.Extensions;
using Kasp.Data.EF.Tests.Data.Repositories;
using Kasp.Data.EF.Tests.Models.NewsModel;
using Kasp.Test;
using Microsoft.EntityFrameworkCore;
using Xunit;
using Xunit.Abstractions;

namespace Kasp.Data.EF.Tests.Tests {
	public class HelperTests : KClassFixtureWebApp<StartupDb> {
		private readonly News _model = new News {
			Title = "this is title", Content = "this is body"
		};

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

			Output.WriteLine(model.ToString());
			var item = await _newsRepository.BaseQuery.EnableFilter().FirstOrDefaultAsync(x => x.Id == model.Id);

			Assert.NotNull(item);
		}

		[Fact]
		public async Task REPOSITORY_FILTERED_EnableTrue() {
			var model = _model;
			model.Enable = true;
			await _newsRepository.AddAsync(model);
			await _newsRepository.SaveAsync();

			Output.WriteLine(model.ToString());
			var item = await _newsRepository.GetAsync(x => x.Id == model.Id);

			Assert.NotNull(item);
		}

		[Fact]
		public async Task EnableFalse() {
			var model = _model;
			model.Enable = false;
			await _newsRepository.AddAsync(model);
			await _newsRepository.SaveAsync();

			Output.WriteLine(model.ToString());
			var item = await _newsRepository.BaseQuery.EnableFilter().FirstOrDefaultAsync(x => x.Id == model.Id);

			Assert.Null(item);
		}

		[Fact]
		public async Task REPOSITORY_FILTERED_EnableFalse() {
			var model = _model;
			model.Enable = false;
			await _newsRepository.AddAsync(model);
			await _newsRepository.SaveAsync();

			Output.WriteLine(model.ToString());
			var item = await _newsRepository.GetFilteredAsync(x => x.Id == model.Id);

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
		public async Task REPOSITORY_FILTERED_BeforePublishTime() {
			var model = _model;
			model.PublishTime = DateTime.UtcNow.AddDays(1);
			await _newsRepository.AddAsync(model);
			await _newsRepository.SaveAsync();

			var item = await _newsRepository.GetFilteredAsync(x => x.Id == model.Id);

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
		[Fact]
		public async Task REPOSITORY_FILTERED_AfterPublishTime() {
			var model = _model;
			model.PublishTime = DateTime.UtcNow.AddDays(-1);
			await _newsRepository.AddAsync(model);
			await _newsRepository.SaveAsync();

			var item = await _newsRepository.GetAsync(x => x.Id == model.Id);

			Assert.NotNull(item);
		}

		public HelperTests(ITestOutputHelper output, KWebAppFactory<StartupDb> factory) : base(output, factory) {
			_newsRepository = GetService<NewsRepository>();
		}
		
	}
}