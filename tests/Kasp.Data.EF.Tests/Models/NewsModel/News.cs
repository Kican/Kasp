using System;
using System.ComponentModel.DataAnnotations;
using AutoMapper;
using Kasp.Data.Models.Helpers;

namespace Kasp.Data.EF.Tests.Models.NewsModel {
	public class News : IModel, ICreateTime, IUpdateTime, IEnable, IPublishTime {
		public int Id { get; set; }

		[Required, MaxLength(200)] public string Title { get; set; }

		[MaxLength(4000)] public string Content { get; set; }

		public DateTime CreateTime { get; set; }
		public DateTime? UpdateTime { get; set; }
		public bool Enable { get; set; }
		public DateTime PublishTime { get; set; }
	}

	public class NewsDto : IModel {
		public int Id { get; set; }
		public string Title { get; set; }
		public DateTime CreateTime { get; set; }
	}

	public class MapperProfile : Profile {
		public MapperProfile() {
			CreateMap<News, NewsDto>();
		}
	}
}