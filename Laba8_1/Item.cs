using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba9
{
    class Item : IDataErrorInfo
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(2)]
        public string Title { get; set; } //название статьи

        [Required]
        [MinLength(2)]
        public string Link { get; set; } //ссылка

        [Required]
        [MinLength(2)]
        public string Description { get; set; } //описание

        [Required]
        public string PubDate { get; set; } //дата публикации

        [ForeignKey("Channel")]
        public int? ChannelId { get; set; }
        public virtual Channel Channel { get; set; }

        public Item()
        {
            Title = "";
            Link = "";
            Description = "";
            PubDate = "";
        }

        public string Error
        {
            get => throw new NotImplementedException();
        }
        public string this[string columnName]
        {
            get
            {
                string errorMessage = null;
                switch (columnName)
                {
                    case "Название видео":
                        if (String.IsNullOrWhiteSpace(Title))
                        {
                            errorMessage = "Нужно название видео!";
                        }
                        break;
                    case "Описание":
                        if (String.IsNullOrWhiteSpace(Description))
                        {
                            errorMessage = "Нужно описание видео!";
                        }
                        break;
                }
                return errorMessage;
            }
        }
    }
}
