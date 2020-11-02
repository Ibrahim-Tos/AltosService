using System;
using System.Globalization;
using Altos.Domain.Features.Products;
using Altos.Util.Application.Dto;
using AutoMapper;

namespace Altos.Services.Features.Products.Dtos
{
    [AutoMap(typeof(ProductInstance))]
    public class ProductInstanceDto : EntityDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public int Availability { get; set; }
        public int InitialAvailability { get; set; }
        public int ProductId { get; set; }

        public override string ToString()
        {
            return $"{Id} - Product: {ProductId} / {StartDateTime}";
        }
        public string ToFormattedString()
        {
            var shortestDayNames = new DateTimeFormatInfo().ShortestDayNames;
            return $"{shortestDayNames[(int)StartDateTime.DayOfWeek]}-{StartDateTime:HH:mm}";
        }
    }
}
