using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace TollywoodMDB.Models
{
    public class TollywoodMDBcontext:DbContext
    {
        public TollywoodMDBcontext() : base("TollywoodMDBContextconn")
        {
        }
        public DbSet<Movies> Movies { get; set; }
        public DbSet<MovieImages> MovieImages { get; set; }
        public DbSet<MovieReviews> MovieReviews { get; set; }
        public DbSet<ReviewReplys> ReviewReplys { get; set; }
        public DbSet<Actors> Actors { get; set; }
        public DbSet<Songs> Songs { get; set; }
        public DbSet<SongAudios> SongAudios { get; set; }
        public DbSet<MovieVideos> MovieVideos { get; set; }
        public DbSet<Logins> Logins { get; set; }
        public DbSet<LoginFiles> LoginFiles { get; set; }
        public DbSet<EmailsTable> EmailsTable { get; set; }
        public DbSet<ActorFiles> ActorFiles { get; set; }
        public DbSet<UserFollowings> UserFollowings { get; set; }
        public DbSet<UserFollowers> UserFollowers { get; set; }
        public DbSet<MovieRatings> MovieRatings { get; set; }
        public DbSet<MovieReleatedData> MovieReleatedData { get; set; }
    }
}