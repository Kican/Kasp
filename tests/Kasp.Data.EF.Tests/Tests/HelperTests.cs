using System;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Kasp.Data.EF.Extensions;
using Kasp.Data.EF.Tests.Data.Repositories;
using Kasp.Data.EF.Tests.Models.NewsModel;
using Kasp.Test;
using Microsoft.EntityFrameworkCore;
using Xunit;
using Xunit.Abstractions;

namespace Kasp.Data.EF.Tests.Tests {
	public class HelperTests : KClassFixtureWebApp<StartupDb> {
		private News TempModel => new News {Title = "this is title", Content = "this is body"};

		private readonly NewsRepository _newsRepository;

		[Fact]
		public async Task ModelTest() {
			var model = TempModel;
			await _newsRepository.AddAsync(model);

			Assert.True(model.Id > 0);
		}

		[Fact]
		public async Task CreateTimeTest() {
			var model = TempModel;
			await _newsRepository.AddAsync(model);

			var item = await _newsRepository.GetAsync<NewsDto>(model.Id);

			Assert.True(item.CreateTime > DateTime.UtcNow.AddMinutes(-1));
		}

		[Fact]
		public async Task UpdateTimeBeforeChangeTest() {
			var model = TempModel;
			await _newsRepository.AddAsync(model);

			Assert.Null(model.UpdateTime);
		}

		[Fact]
		public async Task UpdateTimeAfterChangeTest() {
			var model = TempModel;

			await _newsRepository.AddAsync(model);

			model.Title = "new title";

			await _newsRepository.UpdateAsync(model);

			Assert.NotNull(model.UpdateTime);
			Assert.True(model.UpdateTime > DateTime.UtcNow.AddMinutes(-1));
		}

		[Fact]
		public async Task EnableTrue() {
			var model = TempModel;
			model.Enable = true;
			await _newsRepository.AddAsync(model);
			await _newsRepository.SaveAsync();

			Output.WriteLine(model.ToString());
			var item = await _newsRepository.BaseQuery.EnableFilter().FirstOrDefaultAsync(x => x.Id == model.Id);

			Assert.NotNull(item);
		}

		[Fact]
		public async Task REPOSITORY_FILTERED_EnableTrue() {
			var model = TempModel;
			model.Enable = true;
			await _newsRepository.AddAsync(model);
			await _newsRepository.SaveAsync();

			Output.WriteLine(model.ToString());
			var item = await _newsRepository.GetAsync(x => x.Id == model.Id);

			Assert.NotNull(item);
		}

		[Fact]
		public async Task EnableFalse() {
			var model = TempModel;
			model.Enable = false;
			await _newsRepository.AddAsync(model);
			await _newsRepository.SaveAsync();

			Output.WriteLine(model.ToString());
			var item = await _newsRepository.BaseQuery.EnableFilter().FirstOrDefaultAsync(x => x.Id == model.Id);

			Assert.Null(item);
		}

		// [Fact]
		// public async Task REPOSITORY_FILTERED_EnableFalse() {
		// 	var model = TempModel;
		// 	model.Enable = false;
		// 	await _newsRepository.AddAsync(model);
		//
		// 	Output.WriteLine(model.ToString());
		// 	var item = await _newsRepository.GetAsync(x => x.Id == model.Id);
		//
		// 	Assert.Null(item);
		// }

		[Fact]
		public async Task BeforePublishTime() {
			var model = TempModel;
			model.PublishTime = DateTime.UtcNow.AddDays(1);
			await _newsRepository.AddAsync(model);
			await _newsRepository.SaveAsync();

			var item = await _newsRepository.BaseQuery.PublishTimeFilter().FirstOrDefaultAsync(x => x.Id == model.Id);

			Assert.Null(item);
		}

		// [Fact]
		// public async Task REPOSITORY_FILTERED_BeforePublishTime() {
		// 	var model = TempModel;
		// 	model.PublishTime = DateTime.Now.AddDays(1);
		// 	await _newsRepository.AddAsync(model);
		//
		// 	var item = await _newsRepository.GetAsync(x => x.Id == model.Id);
		//
		// 	Assert.Null(item);
		// }

		[Fact]
		public async Task AfterPublishTime() {
			var model = TempModel;
			model.PublishTime = DateTime.UtcNow.AddDays(-1);
			await _newsRepository.AddAsync(model);
			await _newsRepository.SaveAsync();

			var item = await _newsRepository.BaseQuery.PublishTimeFilter().FirstOrDefaultAsync(x => x.Id == model.Id);

			Assert.NotNull(item);
		}

		[Fact]
		public async Task REPOSITORY_FILTERED_AfterPublishTime() {
			var model = TempModel;
			model.PublishTime = DateTime.UtcNow.AddDays(-1);
			await _newsRepository.AddAsync(model);
			await _newsRepository.SaveAsync();

			var item = await _newsRepository.GetAsync(x => x.Id == model.Id);

			Assert.NotNull(item);
		}


		[Fact]
		public async Task List() {
			var model = TempModel;
			model.PublishTime = DateTime.UtcNow.AddDays(-1);
			await _newsRepository.AddAsync(model);
			await _newsRepository.SaveAsync();

			var item = await _newsRepository.ListAsync(x => x.Id == model.Id && x.Title.Contains(" "), default);

			item.Should().HaveCountGreaterThan(0);

			item.First().Enable = true;
		}

		public HelperTests(ITestOutputHelper output, KWebAppFactory<StartupDb> factory) : base(output, factory) {
			_newsRepository = GetService<NewsRepository>();
		}
	}
}
