using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Laba9;
using Microsoft.EntityFrameworkCore;

namespace Laba9
{//контекст  +  паттерн  Репозиторий
    class ChannelContext : DbContext
    {
        public ChannelContext()
            : base(GetDbContextOptions())
        { }

        private static DbContextOptions<ChannelContext> GetDbContextOptions()
        {
            var builder = new DbContextOptionsBuilder<ChannelContext>();
            builder.UseSqlServer("Data Source=LAPTOP-JIVPNC40\\LOSCHAKOVA;Initial Catalog=ELIBRARY;Integrated Security=True;TrustServerCertificate=true");
            return builder.Options;
        }

        public DbSet<Item> Items { get; set; }
        public DbSet<Channel> Channels { get; set; }
        public DbSet<ChannelImage> ChannelImages { get; set; }
    }
}
