﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace Admin.Models
{
    public class EventNewViewModel
    {
        [Display(Name = "Etkinlik Adı")]
        [Required(ErrorMessage = "Bu alan zorunludur")]
        [MaxLength(200)]
        public string Name { get; set; }

        [Display(Name = "Url")]
        [MaxLength(100)]
        public string Slug { get; set; }

        [Display(Name = "Açıklama")]
        [MaxLength(120)]
        public string Description { get; set; }

        [Display(Name = "İçerik")]
        [DataType(DataType.Html)]
        public string EditorContent { get; set; }

        [Required]
        [Display(Name = "Durum")]
        public int StatusId { get; set; }

        [Display(Name = "Resim Url")]
        [MaxLength(200)]
        public IList<IFormFile> Photos { get; set; }

        [Display(Name = "Lokasyon")]
        [MaxLength(500)]
        public string Location { get; set; }

        [Display(Name = "Başlangıç Tarihi")]
        public DateTime StartDate { get; set; }

        [Display(Name = "Bitiş Tarihi")]
        public DateTime EndDate { get; set; }

        [Display(Name = "Kampüs")]
        [Required(ErrorMessage = "Bu alan zorunludur.")]
        public int CampusId { get; set; }
    }
}
