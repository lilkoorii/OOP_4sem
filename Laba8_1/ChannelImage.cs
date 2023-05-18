﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba9
{
    class ChannelImage //рисунок канала
    {
        [Key]
        [ForeignKey("Channel")]
        public int Id { get; set; }
        public string ImgTitle { get; set; } //название канала
        public string ImgLink { get; set; } //ссылка на сайт
        public string ImgURL { get; set; } //url картинки

        public Channel Channel { get; set; }

        public ChannelImage()
        {
            ImgTitle = "";
            ImgLink = "";
            ImgURL = "";
        }
    }
}