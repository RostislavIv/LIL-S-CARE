﻿namespace LilsCareApp.Core.Models.Details
{
    public class ImageDTO
    {
        public int Id { get; set; }
        public string? ImagePath { get; set; }

        public int ImageOrder { get; set; }

        public bool IsVideo { get; set; } = false;
    }
}