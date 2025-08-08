#nullable disable

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

using Rifoms.Domain.Data.Entities.App;
using Rifoms.Domain.Data.Entities.Web;

namespace Rifoms.Domain.Context
{
    public partial class RifomsDbContext  : IdentityDbContext<AppUser, AppRole, int,
        AppUserClaim, AppUserRole, AppUserLogin, AppRoleClaim, AppUserToken>
    {
        public RifomsDbContext()
        {
        }

        public RifomsDbContext(DbContextOptions<RifomsDbContext> options)
            : base(options)
        {
        }

         protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            #region OLD_CODE
            //if (!optionsBuilder.IsConfigured)
            //{
            //      #warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
            //      optionsBuilder.UseMySql("server=127.0.0.1;port=3306;user=gb_rifoms;password=Sovarizm82!;database=gb_rifoms", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.32-mysql"));
            //}
            #endregion
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            #region App Tables for авторизации пользователей
            modelBuilder.Entity<AppUser>(buildAction: b =>
            {
                b.ToTable("app_users");
                b.HasComment("таблица для app_users");
            });

            modelBuilder.Entity<AppRole>(buildAction: b =>
            {
                b.ToTable("app_roles");
                b.HasComment("таблица для app_roles");
            });

            modelBuilder.Entity<AppRoleClaim>(buildAction: b =>
            {
                b.ToTable("app_roleclaims");
                b.HasComment("таблица для app_roleclaims");
            });

            modelBuilder.Entity<AppUserClaim>(buildAction: b =>
            {
                b.ToTable("app_userclaims");
                b.HasComment("таблица для app_userclaims");
            });

            modelBuilder.Entity<AppUserLogin>(buildAction: b =>
            {
                b.ToTable("app_userlogins");
                //b.HasNoKey();
                b.HasComment("таблица для app_userlogins");
            });

            modelBuilder.Entity<AppUserRole>(buildAction: b =>
            {
                b.ToTable("app_userroles");
                b.HasComment("таблица для app_userroles");
            });

            modelBuilder.Entity<AppUserToken>(buildAction: b =>
            {
                b.ToTable("app_usertokens");
                b.HasComment("таблица для app_usertokens");
            });

            #endregion

            #region CMS Tasbles для САЙТА https://www.rifoms.ru
            
            modelBuilder.HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_unicode_ci");

            modelBuilder.Entity<CmsAction>(entity =>
            {
                entity.ToTable("cms_actions");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_unicode_ci");

                entity.HasIndex(e => new { e.Name, e.IsVisible }, "name");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Component)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("component");

                entity.Property(e => e.IsTracked).HasColumnName("is_tracked");

                entity.Property(e => e.IsVisible).HasColumnName("is_visible");

                entity.Property(e => e.Message)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("message");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("name");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("title");
            });

            modelBuilder.Entity<CmsActionsLog>(entity =>
            {
                entity.ToTable("cms_actions_log");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_unicode_ci");

                entity.HasIndex(e => new { e.ActionId, e.UserId }, "action_id");

                entity.HasIndex(e => e.ObjectId, "object_id");

                entity.HasIndex(e => e.TargetId, "target_id");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ActionId).HasColumnName("action_id");

                entity.Property(e => e.Description)
                    .HasMaxLength(1000)
                    .HasColumnName("description");

                entity.Property(e => e.IsFriendsOnly).HasColumnName("is_friends_only");

                entity.Property(e => e.IsUsersOnly).HasColumnName("is_users_only");

                entity.Property(e => e.Object)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("object");

                entity.Property(e => e.ObjectId).HasColumnName("object_id");

                entity.Property(e => e.ObjectUrl)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("object_url");

                entity.Property(e => e.Pubdate)
                    .HasColumnType("datetime")
                    .HasColumnName("pubdate");

                entity.Property(e => e.Target)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("target");

                entity.Property(e => e.TargetId).HasColumnName("target_id");

                entity.Property(e => e.TargetUrl)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("target_url");

                entity.Property(e => e.UserId).HasColumnName("user_id");
            });

            modelBuilder.Entity<CmsBanlist>(entity =>
            {
                entity.ToTable("cms_banlist");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_unicode_ci");

                entity.HasIndex(e => e.Ip, "ip");

                entity.HasIndex(e => e.UserId, "user_id");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Autodelete).HasColumnName("autodelete");

                entity.Property(e => e.Bandate)
                    .HasColumnType("timestamp")
                    .HasColumnName("bandate")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Cause)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("cause");

                entity.Property(e => e.IntNum).HasColumnName("int_num");

                entity.Property(e => e.IntPeriod)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("int_period");

                entity.Property(e => e.Ip)
                    .IsRequired()
                    .HasMaxLength(15)
                    .HasColumnName("ip");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasColumnName("status")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.UserId).HasColumnName("user_id");
            });

            modelBuilder.Entity<CmsBanner>(entity =>
            {
                entity.ToTable("cms_banners");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Clicks).HasColumnName("clicks");

                entity.Property(e => e.Fileurl)
                    .HasMaxLength(250)
                    .HasColumnName("fileurl");

                entity.Property(e => e.Hits).HasColumnName("hits");

                entity.Property(e => e.Link)
                    .HasMaxLength(250)
                    .HasColumnName("link");

                entity.Property(e => e.Maxhits).HasColumnName("maxhits");

                entity.Property(e => e.Maxuser).HasColumnName("maxuser");

                entity.Property(e => e.Position)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("position")
                    .HasDefaultValueSql("'banner_top'");

                entity.Property(e => e.Pubdate)
                    .HasColumnType("datetime")
                    .HasColumnName("pubdate");

                entity.Property(e => e.Published)
                    .IsRequired()
                    .HasColumnName("published")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Title)
                    .HasMaxLength(250)
                    .HasColumnName("title");

                entity.Property(e => e.Typeimg)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("typeimg")
                    .HasDefaultValueSql("'image'");

                entity.Property(e => e.UserId)
                    .HasColumnName("user_id")
                    .HasDefaultValueSql("'1'");
            });

            modelBuilder.Entity<CmsBannerHit>(entity =>
            {
                entity.ToTable("cms_banner_hits");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_unicode_ci");

                entity.HasIndex(e => e.BannerId, "banner_id");

                entity.HasIndex(e => new { e.Ip, e.BannerId }, "ip")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.BannerId).HasColumnName("banner_id");

                entity.Property(e => e.Ip)
                    .IsRequired()
                    .HasMaxLength(15)
                    .HasColumnName("ip");

                entity.Property(e => e.Pubdate)
                    .HasColumnType("timestamp")
                    .HasColumnName("pubdate")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");
            });

            modelBuilder.Entity<CmsBlog>(entity =>
            {
                entity.ToTable("cms_blogs");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_unicode_ci");

                entity.HasIndex(e => e.Pubdate, "pubdate");

                entity.HasIndex(e => e.Seolink, "seolink");

                entity.HasIndex(e => e.UserId, "user_id");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AllowWho)
                    .IsRequired()
                    .HasMaxLength(15)
                    .HasColumnName("allow_who");

                entity.Property(e => e.CommentsCount).HasColumnName("comments_count");

                entity.Property(e => e.Forall).HasColumnName("forall");

                entity.Property(e => e.Owner)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("owner")
                    .HasDefaultValueSql("'user'");

                entity.Property(e => e.Ownertype)
                    .IsRequired()
                    .HasMaxLength(15)
                    .HasColumnName("ownertype")
                    .HasDefaultValueSql("'single'");

                entity.Property(e => e.Premod).HasColumnName("premod");

                entity.Property(e => e.Pubdate)
                    .HasColumnType("timestamp")
                    .HasColumnName("pubdate")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Rating).HasColumnName("rating");

                entity.Property(e => e.Seolink)
                    .IsRequired()
                    .HasColumnName("seolink");

                entity.Property(e => e.Showcats)
                    .IsRequired()
                    .HasColumnName("showcats")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(250)
                    .HasColumnName("title");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.Property(e => e.ViewType)
                    .IsRequired()
                    .HasMaxLength(15)
                    .HasColumnName("view_type")
                    .HasDefaultValueSql("'list'");
            });

            modelBuilder.Entity<CmsBlogAuthor>(entity =>
            {
                entity.ToTable("cms_blog_authors");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_unicode_ci");

                entity.HasIndex(e => e.BlogId, "blog_id");

                entity.HasIndex(e => e.UserId, "user_id");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.BlogId).HasColumnName("blog_id");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("description");

                entity.Property(e => e.Startdate)
                    .HasColumnType("datetime")
                    .HasColumnName("startdate");

                entity.Property(e => e.UserId).HasColumnName("user_id");
            });

            modelBuilder.Entity<CmsBlogCat>(entity =>
            {
                entity.ToTable("cms_blog_cats");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_unicode_ci");

                entity.HasIndex(e => e.BlogId, "blog_id");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.BlogId).HasColumnName("blog_id");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(1000)
                    .HasColumnName("description");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(250)
                    .HasColumnName("title");
            });

            modelBuilder.Entity<CmsBlogPost>(entity =>
            {
                entity.ToTable("cms_blog_posts");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_unicode_ci");

                entity.HasIndex(e => e.BlogId, "blog_id");

                entity.HasIndex(e => e.ContentHtml, "content_html")
                    .HasAnnotation("MySql:FullTextIndex", true);

                entity.HasIndex(e => e.Seolink, "seolink");

                entity.HasIndex(e => e.Title, "title")
                    .HasAnnotation("MySql:FullTextIndex", true);

                entity.HasIndex(e => e.UserId, "user_id");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AllowWho)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("allow_who");

                entity.Property(e => e.BlogId).HasColumnName("blog_id");

                entity.Property(e => e.CatId).HasColumnName("cat_id");

                entity.Property(e => e.Comments)
                    .IsRequired()
                    .HasColumnName("comments")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.CommentsCount).HasColumnName("comments_count");

                entity.Property(e => e.Content)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("content");

                entity.Property(e => e.ContentHtml)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("content_html");

                entity.Property(e => e.EditDate)
                    .HasColumnType("timestamp")
                    .ValueGeneratedOnAddOrUpdate()
                    .HasColumnName("edit_date")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.EditTimes).HasColumnName("edit_times");

                entity.Property(e => e.Feel)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("feel");

                entity.Property(e => e.Music)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("music");

                entity.Property(e => e.Pubdate)
                    .HasColumnType("datetime")
                    .HasColumnName("pubdate");

                entity.Property(e => e.Published)
                    .IsRequired()
                    .HasColumnName("published")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Rating).HasColumnName("rating");

                entity.Property(e => e.Seolink)
                    .IsRequired()
                    .HasColumnName("seolink");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(250)
                    .HasColumnName("title");

                entity.Property(e => e.UserId).HasColumnName("user_id");
            });

            modelBuilder.Entity<CmsBoardCat>(entity =>
            {
                entity.ToTable("cms_board_cats");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_unicode_ci");

                entity.HasIndex(e => new { e.Nsleft, e.Nsright }, "NSLeft");

                entity.HasIndex(e => e.ParentId, "parent_id");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(300)
                    .HasColumnName("description");

                entity.Property(e => e.FormId).HasColumnName("form_id");

                entity.Property(e => e.Icon)
                    .HasMaxLength(200)
                    .HasColumnName("icon")
                    .HasDefaultValueSql("'folder_grey.png'");

                entity.Property(e => e.IsPhotos)
                    .IsRequired()
                    .HasColumnName("is_photos")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Maxcols)
                    .HasColumnName("maxcols")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Nsdiffer)
                    .IsRequired()
                    .HasMaxLength(15)
                    .HasColumnName("NSDiffer");

                entity.Property(e => e.Nsignore).HasColumnName("NSIgnore");

                entity.Property(e => e.Nsleft).HasColumnName("NSLeft");

                entity.Property(e => e.Nslevel).HasColumnName("NSLevel");

                entity.Property(e => e.Nsright).HasColumnName("NSRight");

                entity.Property(e => e.Obtypes)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("obtypes");

                entity.Property(e => e.Orderby)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("orderby")
                    .HasDefaultValueSql("'title'");

                entity.Property(e => e.Orderform)
                    .HasColumnName("orderform")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Ordering)
                    .HasColumnName("ordering")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Orderto)
                    .IsRequired()
                    .HasMaxLength(4)
                    .HasColumnName("orderto")
                    .HasDefaultValueSql("'asc'");

                entity.Property(e => e.ParentId).HasColumnName("parent_id");

                entity.Property(e => e.Perpage)
                    .HasColumnName("perpage")
                    .HasDefaultValueSql("'15'");

                entity.Property(e => e.Pubdate)
                    .HasColumnType("datetime")
                    .HasColumnName("pubdate");

                entity.Property(e => e.Public).HasColumnName("public");

                entity.Property(e => e.Published).HasColumnName("published");

                entity.Property(e => e.Showdate)
                    .IsRequired()
                    .HasColumnName("showdate")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Thumb1)
                    .HasColumnName("thumb1")
                    .HasDefaultValueSql("'64'");

                entity.Property(e => e.Thumb2)
                    .HasColumnName("thumb2")
                    .HasDefaultValueSql("'400'");

                entity.Property(e => e.Thumbsqr).HasColumnName("thumbsqr");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("title");

                entity.Property(e => e.Uplimit)
                    .HasColumnName("uplimit")
                    .HasDefaultValueSql("'10'");
            });

            modelBuilder.Entity<CmsBoardItem>(entity =>
            {
                entity.ToTable("cms_board_items");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_unicode_ci");

                entity.HasIndex(e => e.CategoryId, "category_id");

                entity.HasIndex(e => e.City, "city");

                entity.HasIndex(e => e.Content, "content")
                    .HasAnnotation("MySql:FullTextIndex", true);

                entity.HasIndex(e => e.Ip, "ip");

                entity.HasIndex(e => e.Obtype, "obtype");

                entity.HasIndex(e => e.Title, "title")
                    .HasAnnotation("MySql:FullTextIndex", true);

                entity.HasIndex(e => e.UserId, "user_id");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CategoryId).HasColumnName("category_id");

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("city");

                entity.Property(e => e.Content)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("content");

                entity.Property(e => e.File)
                    .IsRequired()
                    .HasMaxLength(250)
                    .HasColumnName("file");

                entity.Property(e => e.Formsdata)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("formsdata");

                entity.Property(e => e.Hits).HasColumnName("hits");

                entity.Property(e => e.Ip).HasColumnName("ip");

                entity.Property(e => e.IsVip).HasColumnName("is_vip");

                entity.Property(e => e.MoreImages)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("more_images");

                entity.Property(e => e.Obtype)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("obtype");

                entity.Property(e => e.Pubdate)
                    .HasColumnType("timestamp")
                    .HasColumnName("pubdate")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Pubdays).HasColumnName("pubdays");

                entity.Property(e => e.Published).HasColumnName("published");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(250)
                    .HasColumnName("title");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.Property(e => e.Vipdate)
                    .HasColumnType("datetime")
                    .HasColumnName("vipdate");
            });

            modelBuilder.Entity<CmsCache>(entity =>
            {
                entity.ToTable("cms_cache");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Cachedate)
                    .HasColumnType("datetime")
                    .HasColumnName("cachedate");

                entity.Property(e => e.Cachefile)
                    .IsRequired()
                    .HasMaxLength(80)
                    .HasColumnName("cachefile");

                entity.Property(e => e.Target)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("target");

                entity.Property(e => e.TargetId)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("target_id");
            });

            modelBuilder.Entity<CmsCategory>(entity =>
            {
                entity.ToTable("cms_category");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_unicode_ci");

                entity.HasIndex(e => new { e.Nsleft, e.Nsright }, "NSLeft");

                entity.HasIndex(e => e.ParentId, "parent_id");

                entity.HasIndex(e => e.Seolink, "seolink");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Cost)
                    .IsRequired()
                    .HasMaxLength(5)
                    .HasColumnName("cost");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("description");

                entity.Property(e => e.IsPublic).HasColumnName("is_public");

                entity.Property(e => e.Maxcols)
                    .HasColumnName("maxcols")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.ModgrpId).HasColumnName("modgrp_id");

                entity.Property(e => e.Nsdiffer)
                    .IsRequired()
                    .HasMaxLength(11)
                    .HasColumnName("NSDiffer");

                entity.Property(e => e.Nsignore).HasColumnName("NSIgnore");

                entity.Property(e => e.Nsleft).HasColumnName("NSLeft");

                entity.Property(e => e.Nslevel).HasColumnName("NSLevel");

                entity.Property(e => e.Nsright).HasColumnName("NSRight");

                entity.Property(e => e.Orderby)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("orderby")
                    .HasDefaultValueSql("'date'");

                entity.Property(e => e.Ordering).HasColumnName("ordering");

                entity.Property(e => e.Orderto)
                    .IsRequired()
                    .HasMaxLength(4)
                    .HasColumnName("orderto")
                    .HasDefaultValueSql("'asc'");

                entity.Property(e => e.ParentId).HasColumnName("parent_id");

                entity.Property(e => e.Photoalbum)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("photoalbum");

                entity.Property(e => e.Published).HasColumnName("published");

                entity.Property(e => e.Seolink)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasColumnName("seolink");

                entity.Property(e => e.Showcomm)
                    .IsRequired()
                    .HasColumnName("showcomm")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Showdate)
                    .IsRequired()
                    .HasColumnName("showdate")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Showdesc).HasColumnName("showdesc");

                entity.Property(e => e.Showrss)
                    .IsRequired()
                    .HasColumnName("showrss")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Showtags)
                    .IsRequired()
                    .HasColumnName("showtags")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasColumnName("title");

                entity.Property(e => e.Tpl)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("tpl")
                    .HasDefaultValueSql("'com_content_view.tpl'");

                entity.Property(e => e.Url)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("url");
            });

            modelBuilder.Entity<CmsClub>(entity =>
            {
                entity.ToTable("cms_clubs");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_unicode_ci");

                entity.HasIndex(e => e.AdminId, "admin_id");

                entity.HasIndex(e => e.Pubdate, "pubdate");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AdminId)
                    .HasColumnName("admin_id")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.AlbumMinKarma)
                    .HasColumnName("album_min_karma")
                    .HasDefaultValueSql("'25'");

                entity.Property(e => e.BlogMinKarma).HasColumnName("blog_min_karma");

                entity.Property(e => e.BlogPremod).HasColumnName("blog_premod");

                entity.Property(e => e.Clubtype)
                    .IsRequired()
                    .HasMaxLength(15)
                    .HasColumnName("clubtype")
                    .HasDefaultValueSql("'public'");

                entity.Property(e => e.CreateKarma).HasColumnName("create_karma");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description");

                entity.Property(e => e.EnabledBlogs)
                    .HasColumnName("enabled_blogs")
                    .HasDefaultValueSql("'-1'");

                entity.Property(e => e.EnabledPhotos)
                    .HasColumnName("enabled_photos")
                    .HasDefaultValueSql("'-1'");

                entity.Property(e => e.Imageurl)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("imageurl");

                entity.Property(e => e.IsVip).HasColumnName("is_vip");

                entity.Property(e => e.JoinCost).HasColumnName("join_cost");

                entity.Property(e => e.JoinKarmaLimit).HasColumnName("join_karma_limit");

                entity.Property(e => e.JoinMinKarma).HasColumnName("join_min_karma");

                entity.Property(e => e.Maxsize).HasColumnName("maxsize");

                entity.Property(e => e.MembersCount)
                    .HasColumnName("members_count")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.PhotoMinKarma).HasColumnName("photo_min_karma");

                entity.Property(e => e.PhotoPremod).HasColumnName("photo_premod");

                entity.Property(e => e.Pubdate)
                    .HasColumnType("timestamp")
                    .HasColumnName("pubdate")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Published)
                    .IsRequired()
                    .HasColumnName("published")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Rating).HasColumnName("rating");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasColumnName("title");
            });

            modelBuilder.Entity<CmsComment>(entity =>
            {
                entity.ToTable("cms_comments");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_unicode_ci");

                entity.HasIndex(e => e.TargetId, "target_id");

                entity.HasIndex(e => e.UserId, "user_id");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Content)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("content");

                entity.Property(e => e.ContentBbcode)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("content_bbcode");

                entity.Property(e => e.Guestname)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasColumnName("guestname");

                entity.Property(e => e.Ip)
                    .IsRequired()
                    .HasMaxLength(15)
                    .HasColumnName("ip");

                entity.Property(e => e.IsHidden).HasColumnName("is_hidden");

                entity.Property(e => e.IsNew)
                    .IsRequired()
                    .HasColumnName("is_new")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.ParentId).HasColumnName("parent_id");

                entity.Property(e => e.Pid).HasColumnName("pid");

                entity.Property(e => e.Pubdate)
                    .HasColumnType("timestamp")
                    .HasColumnName("pubdate")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Published)
                    .IsRequired()
                    .HasColumnName("published")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Rating).HasColumnName("rating");

                entity.Property(e => e.Target)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("target");

                entity.Property(e => e.TargetId).HasColumnName("target_id");

                entity.Property(e => e.TargetLink)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasColumnName("target_link");

                entity.Property(e => e.TargetTitle)
                    .IsRequired()
                    .HasMaxLength(150)
                    .HasColumnName("target_title");

                entity.Property(e => e.UserId).HasColumnName("user_id");
            });

            modelBuilder.Entity<CmsCommentTarget>(entity =>
            {
                entity.ToTable("cms_comment_targets");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_unicode_ci");

                entity.HasIndex(e => e.Target, "target")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Component)
                    .IsRequired()
                    .HasMaxLength(32)
                    .HasColumnName("component");

                entity.Property(e => e.Subj)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("subj");

                entity.Property(e => e.Target)
                    .IsRequired()
                    .HasMaxLength(32)
                    .HasColumnName("target");

                entity.Property(e => e.TargetTable)
                    .IsRequired()
                    .HasMaxLength(32)
                    .HasColumnName("target_table");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("title");
            });

            modelBuilder.Entity<CmsComponent>(entity =>
            {
                entity.ToTable("cms_components");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Author)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasColumnName("author")
                    .HasDefaultValueSql("'InstantCMS team'");

                entity.Property(e => e.Config)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("config");

                entity.Property(e => e.Internal).HasColumnName("internal");

                entity.Property(e => e.Link)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasColumnName("link");

                entity.Property(e => e.Published)
                    .IsRequired()
                    .HasColumnName("published")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.System).HasColumnName("system");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasColumnName("title");

                entity.Property(e => e.Version)
                    .IsRequired()
                    .HasMaxLength(6)
                    .HasColumnName("version")
                    .HasDefaultValueSql("'1.10.3'");
            });

            modelBuilder.Entity<CmsContent>(entity =>
            {
                entity.ToTable("cms_content");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_unicode_ci");

                entity.HasIndex(e => e.CategoryId, "category_id");

                entity.HasIndex(e => e.Content, "content")
                    .HasAnnotation("MySql:FullTextIndex", true);

                entity.HasIndex(e => e.Seolink, "seolink");

                entity.HasIndex(e => e.Title, "title")
                    .HasAnnotation("MySql:FullTextIndex", true);

                entity.HasIndex(e => e.UserId, "user_id");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Canrate)
                    .IsRequired()
                    .HasColumnName("canrate")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.CategoryId).HasColumnName("category_id");

                entity.Property(e => e.Comments)
                    .IsRequired()
                    .HasColumnName("comments")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Content)
                    .HasColumnType("longtext")
                    .HasColumnName("content");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("description");

                entity.Property(e => e.Enddate)
                    .HasColumnType("date")
                    .HasColumnName("enddate");

                entity.Property(e => e.Hits).HasColumnName("hits");

                entity.Property(e => e.IsArhive).HasColumnName("is_arhive");

                entity.Property(e => e.IsEnd).HasColumnName("is_end");

                entity.Property(e => e.MetaDesc)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("meta_desc");

                entity.Property(e => e.MetaKeys)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("meta_keys");

                entity.Property(e => e.Ordering).HasColumnName("ordering");

                entity.Property(e => e.Pagetitle)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("pagetitle");

                entity.Property(e => e.Pubdate)
                    .HasColumnType("datetime")
                    .HasColumnName("pubdate")
                    .HasDefaultValueSql("'1000-01-01 00:00:00'");

                entity.Property(e => e.Published)
                    .IsRequired()
                    .HasColumnName("published")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Rating).HasColumnName("rating");

                entity.Property(e => e.Seolink)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasColumnName("seolink");

                entity.Property(e => e.Showdate)
                    .IsRequired()
                    .HasColumnName("showdate")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Showlatest)
                    .IsRequired()
                    .HasColumnName("showlatest")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Showpath)
                    .IsRequired()
                    .HasColumnName("showpath")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Showtitle)
                    .IsRequired()
                    .HasColumnName("showtitle")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(1000)
                    .HasColumnName("title");

                entity.Property(e => e.Tpl)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("tpl")
                    .HasDefaultValueSql("'com_content_read.tpl'");

                entity.Property(e => e.Url)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("url");

                entity.Property(e => e.UserId)
                    .HasColumnName("user_id")
                    .HasDefaultValueSql("'1'");
            });

            modelBuilder.Entity<CmsContentAccess>(entity =>
            {
                entity.ToTable("cms_content_access");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_unicode_ci");

                entity.HasIndex(e => e.ContentId, "content_id");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ContentId).HasColumnName("content_id");

                entity.Property(e => e.ContentType)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("content_type");

                entity.Property(e => e.GroupId).HasColumnName("group_id");
            });

            modelBuilder.Entity<CmsCronJob>(entity =>
            {
                entity.ToTable("cms_cron_jobs");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_unicode_ci");

                entity.HasIndex(e => new { e.JobName, e.IsEnabled }, "job_name");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ClassMethod)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("class_method");

                entity.Property(e => e.ClassName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("class_name");

                entity.Property(e => e.Comment)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasColumnName("comment");

                entity.Property(e => e.Component)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("component");

                entity.Property(e => e.CustomFile)
                    .IsRequired()
                    .HasMaxLength(250)
                    .HasColumnName("custom_file");

                entity.Property(e => e.IsEnabled)
                    .IsRequired()
                    .HasColumnName("is_enabled")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.IsNew)
                    .HasColumnName("is_new")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.JobInterval)
                    .HasColumnName("job_interval")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.JobName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("job_name");

                entity.Property(e => e.JobRunDate)
                    .HasColumnType("timestamp")
                    .HasColumnName("job_run_date")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.ModelMethod)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("model_method");
            });

            modelBuilder.Entity<CmsDownload>(entity =>
            {
                entity.ToTable("cms_downloads");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Fileurl)
                    .IsRequired()
                    .HasMaxLength(250)
                    .HasColumnName("fileurl");

                entity.Property(e => e.Hits).HasColumnName("hits");
            });

            modelBuilder.Entity<CmsEventHook>(entity =>
            {
                entity.ToTable("cms_event_hooks");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_unicode_ci");

                entity.HasIndex(e => new { e.Event, e.PluginId }, "event");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Event)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("event");

                entity.Property(e => e.PluginId)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("plugin_id");
            });

            modelBuilder.Entity<CmsFaqCat>(entity =>
            {
                entity.ToTable("cms_faq_cats");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("description");

                entity.Property(e => e.ParentId).HasColumnName("parent_id");

                entity.Property(e => e.Published)
                    .IsRequired()
                    .HasColumnName("published")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(250)
                    .HasColumnName("title");
            });

            modelBuilder.Entity<CmsFaqQuest>(entity =>
            {
                entity.ToTable("cms_faq_quests");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_unicode_ci");

                entity.HasIndex(e => e.CategoryId, "category_id");

                entity.HasIndex(e => new { e.Quest, e.Answer }, "quest")
                    .HasAnnotation("MySql:FullTextIndex", true);

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Answer)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("answer");

                entity.Property(e => e.Answerdate)
                    .HasColumnType("datetime")
                    .HasColumnName("answerdate");

                entity.Property(e => e.AnsweruserId).HasColumnName("answeruser_id");

                entity.Property(e => e.CategoryId).HasColumnName("category_id");

                entity.Property(e => e.Hits).HasColumnName("hits");

                entity.Property(e => e.Pubdate)
                    .HasColumnType("datetime")
                    .HasColumnName("pubdate");

                entity.Property(e => e.Published).HasColumnName("published");

                entity.Property(e => e.Quest)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("quest");

                entity.Property(e => e.UserId).HasColumnName("user_id");
            });

            modelBuilder.Entity<CmsFilter>(entity =>
            {
                entity.ToTable("cms_filters");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("description");

                entity.Property(e => e.Link)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("link");

                entity.Property(e => e.Published).HasColumnName("published");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("title");
            });

            modelBuilder.Entity<CmsForm>(entity =>
            {
                entity.ToTable("cms_forms");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_unicode_ci");

                entity.HasIndex(e => e.Title, "title");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("description");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasColumnName("email");

                entity.Property(e => e.FormAction)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasColumnName("form_action")
                    .HasDefaultValueSql("'/forms/process'");

                entity.Property(e => e.OnlyFields).HasColumnName("only_fields");

                entity.Property(e => e.Sendto)
                    .IsRequired()
                    .HasMaxLength(4)
                    .HasColumnName("sendto")
                    .HasDefaultValueSql("'mail'");

                entity.Property(e => e.Showtitle)
                    .IsRequired()
                    .HasColumnName("showtitle")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasColumnName("title");

                entity.Property(e => e.Tpl)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("tpl")
                    .HasDefaultValueSql("'form'");

                entity.Property(e => e.UserId)
                    .HasColumnName("user_id")
                    .HasDefaultValueSql("'1'");
            });

            modelBuilder.Entity<CmsFormField>(entity =>
            {
                entity.ToTable("cms_form_fields");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_unicode_ci");

                entity.HasIndex(e => e.FormId, "form_id");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Config)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("config");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasColumnName("description")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.FormId).HasColumnName("form_id");

                entity.Property(e => e.Kind)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("kind");

                entity.Property(e => e.Mustbe).HasColumnName("mustbe");

                entity.Property(e => e.Ordering).HasColumnName("ordering");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasColumnName("title");
            });

            modelBuilder.Entity<CmsForum>(entity =>
            {
                entity.ToTable("cms_forums");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_unicode_ci");

                entity.HasIndex(e => new { e.Nsleft, e.Nsright }, "NSLeft");

                entity.HasIndex(e => e.CategoryId, "category_id");

                entity.HasIndex(e => e.ParentId, "parent_id");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AccessList)
                    .IsRequired()
                    .HasColumnType("tinytext")
                    .HasColumnName("access_list");

                entity.Property(e => e.CategoryId).HasColumnName("category_id");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(300)
                    .HasColumnName("description");

                entity.Property(e => e.Icon)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasColumnName("icon");

                entity.Property(e => e.LastMsg)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("last_msg");

                entity.Property(e => e.ModerList)
                    .IsRequired()
                    .HasColumnType("tinytext")
                    .HasColumnName("moder_list");

                entity.Property(e => e.Nsdiffer)
                    .IsRequired()
                    .HasMaxLength(15)
                    .HasColumnName("NSDiffer");

                entity.Property(e => e.Nsignore).HasColumnName("NSIgnore");

                entity.Property(e => e.Nsleft).HasColumnName("NSLeft");

                entity.Property(e => e.Nslevel).HasColumnName("NSLevel");

                entity.Property(e => e.Nsright).HasColumnName("NSRight");

                entity.Property(e => e.Ordering).HasColumnName("ordering");

                entity.Property(e => e.ParentId).HasColumnName("parent_id");

                entity.Property(e => e.PostCount).HasColumnName("post_count");

                entity.Property(e => e.Published)
                    .IsRequired()
                    .HasColumnName("published")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.ThreadCount).HasColumnName("thread_count");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(250)
                    .HasColumnName("title");

                entity.Property(e => e.TopicCost).HasColumnName("topic_cost");
            });

            modelBuilder.Entity<CmsForumCat>(entity =>
            {
                entity.ToTable("cms_forum_cats");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_unicode_ci");

                entity.HasIndex(e => e.Seolink, "seolink");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Ordering).HasColumnName("ordering");

                entity.Property(e => e.Published)
                    .IsRequired()
                    .HasColumnName("published")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Seolink)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasColumnName("seolink");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(250)
                    .HasColumnName("title");
            });

            modelBuilder.Entity<CmsForumFile>(entity =>
            {
                entity.ToTable("cms_forum_files");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_unicode_ci");

                entity.HasIndex(e => e.PostId, "post_id");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Filename)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasColumnName("filename");

                entity.Property(e => e.Filesize).HasColumnName("filesize");

                entity.Property(e => e.Hits).HasColumnName("hits");

                entity.Property(e => e.PostId).HasColumnName("post_id");

                entity.Property(e => e.Pubdate)
                    .HasColumnType("datetime")
                    .HasColumnName("pubdate");
            });

            modelBuilder.Entity<CmsForumPoll>(entity =>
            {
                entity.ToTable("cms_forum_polls");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_unicode_ci");

                entity.HasIndex(e => e.ThreadId, "thread_id");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Answers)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("answers");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("description");

                entity.Property(e => e.Enddate)
                    .HasColumnType("datetime")
                    .HasColumnName("enddate");

                entity.Property(e => e.Options)
                    .IsRequired()
                    .HasMaxLength(250)
                    .HasColumnName("options");

                entity.Property(e => e.ThreadId).HasColumnName("thread_id");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasColumnName("title");
            });

            modelBuilder.Entity<CmsForumPost>(entity =>
            {
                entity.ToTable("cms_forum_posts");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_unicode_ci");

                entity.HasIndex(e => e.ContentHtml, "content_html")
                    .HasAnnotation("MySql:FullTextIndex", true);

                entity.HasIndex(e => new { e.ThreadId, e.Pubdate }, "thread_id");

                entity.HasIndex(e => e.UserId, "user_id");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AttachCount).HasColumnName("attach_count");

                entity.Property(e => e.Content)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("content");

                entity.Property(e => e.ContentHtml)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("content_html");

                entity.Property(e => e.Editdate)
                    .HasColumnType("datetime")
                    .HasColumnName("editdate");

                entity.Property(e => e.Edittimes).HasColumnName("edittimes");

                entity.Property(e => e.Pinned).HasColumnName("pinned");

                entity.Property(e => e.Pubdate)
                    .HasColumnType("datetime")
                    .HasColumnName("pubdate");

                entity.Property(e => e.Rating).HasColumnName("rating");

                entity.Property(e => e.ThreadId).HasColumnName("thread_id");

                entity.Property(e => e.UserId).HasColumnName("user_id");
            });

            modelBuilder.Entity<CmsForumThread>(entity =>
            {
                entity.ToTable("cms_forum_threads");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_unicode_ci");

                entity.HasIndex(e => e.ForumId, "forum_id");

                entity.HasIndex(e => e.RelId, "rel_id");

                entity.HasIndex(e => e.Title, "title")
                    .HasAnnotation("MySql:FullTextIndex", true);

                entity.HasIndex(e => e.UserId, "user_id");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Closed).HasColumnName("closed");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(250)
                    .HasColumnName("description");

                entity.Property(e => e.ForumId).HasColumnName("forum_id");

                entity.Property(e => e.Hits).HasColumnName("hits");

                entity.Property(e => e.Icon)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("icon");

                entity.Property(e => e.IsHidden).HasColumnName("is_hidden");

                entity.Property(e => e.LastMsg)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("last_msg");

                entity.Property(e => e.Pinned).HasColumnName("pinned");

                entity.Property(e => e.PostCount).HasColumnName("post_count");

                entity.Property(e => e.Pubdate)
                    .HasColumnType("datetime")
                    .HasColumnName("pubdate");

                entity.Property(e => e.RelId).HasColumnName("rel_id");

                entity.Property(e => e.RelTo)
                    .IsRequired()
                    .HasMaxLength(15)
                    .HasColumnName("rel_to");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(250)
                    .HasColumnName("title");

                entity.Property(e => e.UserId).HasColumnName("user_id");
            });

            modelBuilder.Entity<CmsForumVote>(entity =>
            {
                entity.ToTable("cms_forum_votes");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_unicode_ci");

                entity.HasIndex(e => e.PollId, "poll_id");

                entity.HasIndex(e => e.UserId, "user_id");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Answer)
                    .IsRequired()
                    .HasMaxLength(300)
                    .HasColumnName("answer");

                entity.Property(e => e.PollId).HasColumnName("poll_id");

                entity.Property(e => e.Pubdate)
                    .HasColumnType("datetime")
                    .HasColumnName("pubdate");

                entity.Property(e => e.UserId).HasColumnName("user_id");
            });

            modelBuilder.Entity<CmsGeoCity>(entity =>
            {
                entity.ToTable("cms_geo_cities");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_unicode_ci");

                entity.HasIndex(e => e.CountryId, "country_id");

                entity.HasIndex(e => e.Name, "name");

                entity.HasIndex(e => e.RegionId, "region_id");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CountryId).HasColumnName("country_id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(128)
                    .HasColumnName("name")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.RegionId).HasColumnName("region_id");
            });

            modelBuilder.Entity<CmsGeoCountry>(entity =>
            {
                entity.ToTable("cms_geo_countries");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_unicode_ci");

                entity.HasIndex(e => e.Alpha2, "alpha2");

                entity.HasIndex(e => e.Alpha3, "alpha3");

                entity.HasIndex(e => e.Iso, "iso");

                entity.HasIndex(e => e.Name, "name");

                entity.HasIndex(e => e.Ordering, "ordering");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Alpha2)
                    .IsRequired()
                    .HasMaxLength(2)
                    .HasColumnName("alpha2")
                    .HasDefaultValueSql("''")
                    .IsFixedLength(true);

                entity.Property(e => e.Alpha3)
                    .IsRequired()
                    .HasMaxLength(3)
                    .HasColumnName("alpha3")
                    .HasDefaultValueSql("''")
                    .IsFixedLength(true);

                entity.Property(e => e.Iso).HasColumnName("iso");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(128)
                    .HasColumnName("name")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Ordering)
                    .HasColumnName("ordering")
                    .HasDefaultValueSql("'100'");
            });

            modelBuilder.Entity<CmsGeoRegion>(entity =>
            {
                entity.ToTable("cms_geo_regions");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_unicode_ci");

                entity.HasIndex(e => e.CountryId, "country_id");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CountryId).HasColumnName("country_id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("name")
                    .HasDefaultValueSql("''");
            });

            modelBuilder.Entity<CmsMenu>(entity =>
            {
                entity.ToTable("cms_menu");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_unicode_ci");

                entity.HasIndex(e => new { e.Nsleft, e.Nsright }, "NSLeft");

                entity.HasIndex(e => e.ParentId, "parent_id");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AccessList)
                    .IsRequired()
                    .HasColumnType("tinytext")
                    .HasColumnName("access_list");

                entity.Property(e => e.Component)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("component");

                entity.Property(e => e.Iconurl)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("iconurl");

                entity.Property(e => e.Link)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasColumnName("link");

                entity.Property(e => e.Linkid)
                    .HasMaxLength(25)
                    .HasColumnName("linkid")
                    .HasDefaultValueSql("'-1'");

                entity.Property(e => e.Linktype)
                    .IsRequired()
                    .HasMaxLength(12)
                    .HasColumnName("linktype")
                    .HasDefaultValueSql("'link'");

                entity.Property(e => e.Menu)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasColumnName("menu");

                entity.Property(e => e.Nsdiffer)
                    .HasMaxLength(40)
                    .HasColumnName("NSDiffer");

                entity.Property(e => e.Nsignore).HasColumnName("NSIgnore");

                entity.Property(e => e.Nsleft).HasColumnName("NSLeft");

                entity.Property(e => e.Nslevel).HasColumnName("NSLevel");

                entity.Property(e => e.Nsright).HasColumnName("NSRight");

                entity.Property(e => e.Ordering)
                    .HasColumnName("ordering")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.ParentId).HasColumnName("parent_id");

                entity.Property(e => e.Published).HasColumnName("published");

                entity.Property(e => e.Target)
                    .IsRequired()
                    .HasMaxLength(8)
                    .HasColumnName("target")
                    .HasDefaultValueSql("'_self'");

                entity.Property(e => e.Template)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("template");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasColumnName("title");
            });

            modelBuilder.Entity<CmsModule>(entity =>
            {
                entity.ToTable("cms_modules");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_unicode_ci");

                entity.HasIndex(e => e.Content, "content")
                    .HasAnnotation("MySql:FullTextIndex", true);

                entity.HasIndex(e => e.Position, "position");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AccessList)
                    .IsRequired()
                    .HasColumnType("tinytext")
                    .HasColumnName("access_list");

                entity.Property(e => e.Author)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("author")
                    .HasDefaultValueSql("'InstantCMS team'");

                entity.Property(e => e.Cache).HasColumnName("cache");

                entity.Property(e => e.Cacheint)
                    .IsRequired()
                    .HasMaxLength(15)
                    .HasColumnName("cacheint")
                    .HasDefaultValueSql("'HOUR'");

                entity.Property(e => e.Cachetime)
                    .HasColumnName("cachetime")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Config)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("config");

                entity.Property(e => e.Content)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("content");

                entity.Property(e => e.CssPrefix)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("css_prefix");

                entity.Property(e => e.IsExternal).HasColumnName("is_external");

                entity.Property(e => e.IsStrictBind).HasColumnName("is_strict_bind");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasColumnName("name");

                entity.Property(e => e.Ordering)
                    .HasColumnName("ordering")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Original)
                    .HasColumnName("original")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Position)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("position");

                entity.Property(e => e.Published)
                    .IsRequired()
                    .HasColumnName("published")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Showtitle)
                    .HasColumnName("showtitle")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Template)
                    .IsRequired()
                    .HasMaxLength(35)
                    .HasColumnName("template")
                    .HasDefaultValueSql("'module.tpl'");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasColumnName("title");

                entity.Property(e => e.User).HasColumnName("user");

                entity.Property(e => e.Version)
                    .IsRequired()
                    .HasMaxLength(6)
                    .HasColumnName("version")
                    .HasDefaultValueSql("'1.0'");
            });

            modelBuilder.Entity<CmsModulesBind>(entity =>
            {
                entity.ToTable("cms_modules_bind");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_unicode_ci");

                entity.HasIndex(e => e.MenuId, "menu_id");

                entity.HasIndex(e => e.ModuleId, "module_id");

                entity.HasIndex(e => e.Position, "position");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.MenuId).HasColumnName("menu_id");

                entity.Property(e => e.ModuleId).HasColumnName("module_id");

                entity.Property(e => e.Position)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("position");
            });

            modelBuilder.Entity<CmsNsTransaction>(entity =>
            {
                entity.HasKey(e => e.Idtransaction)
                    .HasName("PRIMARY");

                entity.ToTable("cms_ns_transactions");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.Idtransaction).HasColumnName("IDTransaction");

                entity.Property(e => e.Differ).HasColumnType("tinytext");

                entity.Property(e => e.InTransaction).HasColumnType("bit(1)");

                entity.Property(e => e.TableName).HasColumnType("tinytext");

                entity.Property(e => e.Tstamp)
                    .HasColumnType("timestamp")
                    .HasColumnName("TStamp");
            });

            modelBuilder.Entity<CmsOnline>(entity =>
            {
                entity.ToTable("cms_online");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_unicode_ci");

                entity.HasIndex(e => e.SessId, "sess_id")
                    .IsUnique();

                entity.HasIndex(e => e.UserId, "user_id");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Agent)
                    .IsRequired()
                    .HasMaxLength(250)
                    .HasColumnName("agent");

                entity.Property(e => e.Ip)
                    .IsRequired()
                    .HasMaxLength(15)
                    .HasColumnName("ip");

                entity.Property(e => e.Lastdate)
                    .HasColumnType("timestamp")
                    .ValueGeneratedOnAddOrUpdate()
                    .HasColumnName("lastdate")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.SessId)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("sess_id");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.Property(e => e.Viewurl)
                    .IsRequired()
                    .HasMaxLength(250)
                    .HasColumnName("viewurl");
            });

            modelBuilder.Entity<CmsPhotoAlbum>(entity =>
            {
                entity.ToTable("cms_photo_albums");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_unicode_ci");

                entity.HasIndex(e => new { e.Nsleft, e.Nsright }, "NSLeft");

                entity.HasIndex(e => e.ParentId, "parent_id");

                entity.HasIndex(e => e.UserId, "user_id");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Bbcode)
                    .IsRequired()
                    .HasColumnName("bbcode")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Cssprefix)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("cssprefix");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(300)
                    .HasColumnName("description");

                entity.Property(e => e.Iconurl)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("iconurl");

                entity.Property(e => e.IsComments).HasColumnName("is_comments");

                entity.Property(e => e.Maxcols)
                    .HasColumnName("maxcols")
                    .HasDefaultValueSql("'4'");

                entity.Property(e => e.Nav)
                    .IsRequired()
                    .HasColumnName("nav")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Nsdiffer)
                    .IsRequired()
                    .HasMaxLength(15)
                    .HasColumnName("NSDiffer");

                entity.Property(e => e.Nsignore).HasColumnName("NSIgnore");

                entity.Property(e => e.Nsleft).HasColumnName("NSLeft");

                entity.Property(e => e.Nslevel).HasColumnName("NSLevel");

                entity.Property(e => e.Nsright).HasColumnName("NSRight");

                entity.Property(e => e.Orderby)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("orderby")
                    .HasDefaultValueSql("'title'");

                entity.Property(e => e.Orderform)
                    .IsRequired()
                    .HasColumnName("orderform")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Ordering)
                    .HasColumnName("ordering")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Orderto)
                    .IsRequired()
                    .HasMaxLength(4)
                    .HasColumnName("orderto")
                    .HasDefaultValueSql("'asc'");

                entity.Property(e => e.ParentId).HasColumnName("parent_id");

                entity.Property(e => e.Perpage)
                    .HasColumnName("perpage")
                    .HasDefaultValueSql("'15'");

                entity.Property(e => e.Pubdate)
                    .HasColumnType("timestamp")
                    .HasColumnName("pubdate")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Public).HasColumnName("public");

                entity.Property(e => e.Published).HasColumnName("published");

                entity.Property(e => e.Showdate)
                    .IsRequired()
                    .HasColumnName("showdate")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Showtags)
                    .IsRequired()
                    .HasColumnName("showtags")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Showtype)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("showtype")
                    .HasDefaultValueSql("'lightbox'");

                entity.Property(e => e.Thumb1)
                    .HasColumnName("thumb1")
                    .HasDefaultValueSql("'96'");

                entity.Property(e => e.Thumb2)
                    .HasColumnName("thumb2")
                    .HasDefaultValueSql("'480'");

                entity.Property(e => e.Thumbsqr)
                    .IsRequired()
                    .HasColumnName("thumbsqr")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("title");

                entity.Property(e => e.Uplimit).HasColumnName("uplimit");

                entity.Property(e => e.UserId)
                    .HasColumnName("user_id")
                    .HasDefaultValueSql("'1'");
            });

            modelBuilder.Entity<CmsPhotoFile>(entity =>
            {
                entity.ToTable("cms_photo_files");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_unicode_ci");

                entity.HasIndex(e => e.AlbumId, "album_id");

                entity.HasIndex(e => e.Owner, "owner");

                entity.HasIndex(e => new { e.Title, e.Description }, "title")
                    .HasAnnotation("MySql:FullTextIndex", true);

                entity.HasIndex(e => e.UserId, "user_id");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AlbumId).HasColumnName("album_id");

                entity.Property(e => e.Comments)
                    .IsRequired()
                    .HasColumnName("comments")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("description");

                entity.Property(e => e.File)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasColumnName("file");

                entity.Property(e => e.Hits).HasColumnName("hits");

                entity.Property(e => e.Owner)
                    .HasMaxLength(10)
                    .HasColumnName("owner")
                    .HasDefaultValueSql("'photos'");

                entity.Property(e => e.Pubdate)
                    .HasColumnType("timestamp")
                    .HasColumnName("pubdate")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Published).HasColumnName("published");

                entity.Property(e => e.Rating).HasColumnName("rating");

                entity.Property(e => e.Showdate)
                    .IsRequired()
                    .HasColumnName("showdate")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasColumnName("title");

                entity.Property(e => e.UserId)
                    .HasColumnName("user_id")
                    .HasDefaultValueSql("'1'");
            });

            modelBuilder.Entity<CmsPlugin>(entity =>
            {
                entity.ToTable("cms_plugins");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Author)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("author");

                entity.Property(e => e.Config)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("config");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("description");

                entity.Property(e => e.Plugin)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("plugin");

                entity.Property(e => e.PluginType)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("plugin_type");

                entity.Property(e => e.Published).HasColumnName("published");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("title");

                entity.Property(e => e.Version)
                    .IsRequired()
                    .HasMaxLength(15)
                    .HasColumnName("version");
            });

            modelBuilder.Entity<CmsPoll>(entity =>
            {
                entity.ToTable("cms_polls");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Answers)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("answers");

                entity.Property(e => e.Pubdate)
                    .HasColumnType("timestamp")
                    .HasColumnName("pubdate")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasColumnName("title");
            });

            modelBuilder.Entity<CmsPollsLog>(entity =>
            {
                entity.ToTable("cms_polls_log");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_unicode_ci");

                entity.HasIndex(e => e.Ip, "ip");

                entity.HasIndex(e => e.PollId, "poll_id");

                entity.HasIndex(e => e.UserId, "user_id");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Answer)
                    .IsRequired()
                    .HasMaxLength(300)
                    .HasColumnName("answer");

                entity.Property(e => e.Ip)
                    .IsRequired()
                    .HasMaxLength(15)
                    .HasColumnName("ip");

                entity.Property(e => e.PollId).HasColumnName("poll_id");

                entity.Property(e => e.UserId).HasColumnName("user_id");
            });

            modelBuilder.Entity<CmsRating>(entity =>
            {
                entity.ToTable("cms_ratings");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_unicode_ci");

                entity.HasIndex(e => e.ItemId, "item_id");

                entity.HasIndex(e => e.UserId, "user_id");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Ip)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("ip");

                entity.Property(e => e.ItemId).HasColumnName("item_id");

                entity.Property(e => e.Points).HasColumnName("points");

                entity.Property(e => e.Pubdate)
                    .HasColumnType("datetime")
                    .HasColumnName("pubdate");

                entity.Property(e => e.Target)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("target");

                entity.Property(e => e.UserId)
                    .HasColumnName("user_id")
                    .HasDefaultValueSql("'1'");
            });

            modelBuilder.Entity<CmsRatingTarget>(entity =>
            {
                entity.ToTable("cms_rating_targets");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_unicode_ci");

                entity.HasIndex(e => e.Target, "target")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Component)
                    .IsRequired()
                    .HasMaxLength(32)
                    .HasColumnName("component");

                entity.Property(e => e.IsUserAffect).HasColumnName("is_user_affect");

                entity.Property(e => e.Target)
                    .IsRequired()
                    .HasMaxLength(32)
                    .HasColumnName("target");

                entity.Property(e => e.TargetTable)
                    .IsRequired()
                    .HasMaxLength(32)
                    .HasColumnName("target_table");

                entity.Property(e => e.TargetTitle)
                    .IsRequired()
                    .HasMaxLength(70)
                    .HasColumnName("target_title");

                entity.Property(e => e.UserWeight).HasColumnName("user_weight");
            });

            modelBuilder.Entity<CmsRatingsTotal>(entity =>
            {
                entity.ToTable("cms_ratings_total");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_unicode_ci");

                entity.HasIndex(e => e.ItemId, "item_id");

                entity.HasIndex(e => new { e.Target, e.ItemId }, "target");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ItemId)
                    .HasColumnType("mediumint")
                    .HasColumnName("item_id");

                entity.Property(e => e.Target)
                    .IsRequired()
                    .HasMaxLength(32)
                    .HasColumnName("target");

                entity.Property(e => e.TotalRating).HasColumnName("total_rating");

                entity.Property(e => e.TotalVotes).HasColumnName("total_votes");
            });

            modelBuilder.Entity<CmsSearch>(entity =>
            {
                entity.ToTable("cms_search");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_unicode_ci");

                entity.HasIndex(e => e.Date, "date");

                entity.HasIndex(e => e.SessionId, "session_id");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Date)
                    .HasColumnType("timestamp")
                    .HasColumnName("date")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(500)
                    .HasColumnName("description");

                entity.Property(e => e.Link)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasColumnName("link");

                entity.Property(e => e.Place)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("place");

                entity.Property(e => e.Placelink)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasColumnName("placelink");

                entity.Property(e => e.Pubdate)
                    .HasColumnType("datetime")
                    .HasColumnName("pubdate");

                entity.Property(e => e.SessionId)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("session_id");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(250)
                    .HasColumnName("title");
            });

            modelBuilder.Entity<CmsSubscribe>(entity =>
            {
                entity.ToTable("cms_subscribe");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_unicode_ci");

                entity.HasIndex(e => e.TargetId, "target_id");

                entity.HasIndex(e => e.UserId, "user_id");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Pubdate)
                    .HasColumnType("datetime")
                    .HasColumnName("pubdate");

                entity.Property(e => e.Target)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("target");

                entity.Property(e => e.TargetId).HasColumnName("target_id");

                entity.Property(e => e.UserId).HasColumnName("user_id");
            });

            modelBuilder.Entity<CmsTag>(entity =>
            {
                entity.ToTable("cms_tags");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_unicode_ci");

                entity.HasIndex(e => e.ItemId, "item_id");

                entity.HasIndex(e => e.Tag, "tag");

                entity.HasIndex(e => new { e.Target, e.Tag }, "target");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ItemId).HasColumnName("item_id");

                entity.Property(e => e.Tag)
                    .IsRequired()
                    .HasMaxLength(250)
                    .HasColumnName("tag");

                entity.Property(e => e.Target)
                    .IsRequired()
                    .HasMaxLength(25)
                    .HasColumnName("target");
            });

            modelBuilder.Entity<CmsTagTarget>(entity =>
            {
                entity.ToTable("cms_tag_targets");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_unicode_ci");

                entity.HasIndex(e => e.Target, "target")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Component)
                    .IsRequired()
                    .HasMaxLength(32)
                    .HasColumnName("component");

                entity.Property(e => e.Target)
                    .IsRequired()
                    .HasMaxLength(32)
                    .HasColumnName("target");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(70)
                    .HasColumnName("title");
            });

            modelBuilder.Entity<CmsUcCart>(entity =>
            {
                entity.ToTable("cms_uc_cart");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ItemId).HasColumnName("item_id");

                entity.Property(e => e.Itemscount).HasColumnName("itemscount");

                entity.Property(e => e.Pubdate)
                    .HasColumnType("datetime")
                    .HasColumnName("pubdate");

                entity.Property(e => e.SessionId)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("session_id");

                entity.Property(e => e.UserId).HasColumnName("user_id");
            });

            modelBuilder.Entity<CmsUcCat>(entity =>
            {
                entity.ToTable("cms_uc_cats");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_unicode_ci");

                entity.HasIndex(e => new { e.Nsleft, e.Nsright }, "NSLeft");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CanEdit).HasColumnName("can_edit");

                entity.Property(e => e.Cost)
                    .IsRequired()
                    .HasMaxLength(5)
                    .HasColumnName("cost");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("description");

                entity.Property(e => e.FieldsShow)
                    .HasColumnName("fields_show")
                    .HasDefaultValueSql("'10'");

                entity.Property(e => e.Fieldsstruct)
                    .HasColumnType("text")
                    .HasColumnName("fieldsstruct");

                entity.Property(e => e.Filters).HasColumnName("filters");

                entity.Property(e => e.IsPublic).HasColumnName("is_public");

                entity.Property(e => e.IsRatings).HasColumnName("is_ratings");

                entity.Property(e => e.IsShop).HasColumnName("is_shop");

                entity.Property(e => e.Newint)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("newint");

                entity.Property(e => e.Nsdiffer).HasColumnName("NSDiffer");

                entity.Property(e => e.Nsignore).HasColumnName("NSIgnore");

                entity.Property(e => e.Nsleft).HasColumnName("NSLeft");

                entity.Property(e => e.Nslevel).HasColumnName("NSLevel");

                entity.Property(e => e.Nsright).HasColumnName("NSRight");

                entity.Property(e => e.Orderby)
                    .IsRequired()
                    .HasMaxLength(12)
                    .HasColumnName("orderby")
                    .HasDefaultValueSql("'pubdate'");

                entity.Property(e => e.Ordering).HasColumnName("ordering");

                entity.Property(e => e.Orderto)
                    .HasMaxLength(10)
                    .HasColumnName("orderto")
                    .HasDefaultValueSql("'desc'");

                entity.Property(e => e.ParentId).HasColumnName("parent_id");

                entity.Property(e => e.Perpage)
                    .HasColumnName("perpage")
                    .HasDefaultValueSql("'20'");

                entity.Property(e => e.Published)
                    .IsRequired()
                    .HasColumnName("published")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Showabc)
                    .IsRequired()
                    .HasColumnName("showabc")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Showmore)
                    .IsRequired()
                    .HasColumnName("showmore")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Shownew).HasColumnName("shownew");

                entity.Property(e => e.Showsort)
                    .IsRequired()
                    .HasColumnName("showsort")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Showtags)
                    .IsRequired()
                    .HasColumnName("showtags")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasColumnName("title");

                entity.Property(e => e.ViewType)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("view_type")
                    .HasDefaultValueSql("'list'");
            });

            modelBuilder.Entity<CmsUcCatsAccess>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("cms_uc_cats_access");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_unicode_ci");

                entity.HasIndex(e => new { e.CatId, e.GroupId }, "cat_id");

                entity.Property(e => e.CatId).HasColumnName("cat_id");

                entity.Property(e => e.GroupId).HasColumnName("group_id");
            });

            modelBuilder.Entity<CmsUcDiscount>(entity =>
            {
                entity.ToTable("cms_uc_discount");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_unicode_ci");

                entity.HasIndex(e => e.CatId, "cat_id");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CatId).HasColumnName("cat_id");

                entity.Property(e => e.IfLimit).HasColumnName("if_limit");

                entity.Property(e => e.Sign).HasColumnName("sign");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(150)
                    .HasColumnName("title");

                entity.Property(e => e.Unit)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("unit");

                entity.Property(e => e.Value).HasColumnName("value");
            });

            modelBuilder.Entity<CmsUcItem>(entity =>
            {
                entity.ToTable("cms_uc_items");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_unicode_ci");

                entity.HasIndex(e => e.CategoryId, "category_id");

                entity.HasIndex(e => new { e.Title, e.Fieldsdata }, "title")
                    .HasAnnotation("MySql:FullTextIndex", true);

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Canmany)
                    .HasColumnName("canmany")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.CategoryId).HasColumnName("category_id");

                entity.Property(e => e.Fieldsdata)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("fieldsdata");

                entity.Property(e => e.Hits).HasColumnName("hits");

                entity.Property(e => e.Imageurl)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasColumnName("imageurl");

                entity.Property(e => e.IsComments).HasColumnName("is_comments");

                entity.Property(e => e.MetaDesc)
                    .IsRequired()
                    .HasMaxLength(250)
                    .HasColumnName("meta_desc");

                entity.Property(e => e.MetaKeys)
                    .IsRequired()
                    .HasMaxLength(250)
                    .HasColumnName("meta_keys");

                entity.Property(e => e.OnModerate).HasColumnName("on_moderate");

                entity.Property(e => e.Price).HasColumnName("price");

                entity.Property(e => e.Pubdate)
                    .HasColumnType("datetime")
                    .HasColumnName("pubdate")
                    .HasDefaultValueSql("'1000-01-01 00:00:00'");

                entity.Property(e => e.Published)
                    .IsRequired()
                    .HasColumnName("published")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Rating).HasColumnName("rating");

                entity.Property(e => e.Tags)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasColumnName("tags");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasColumnName("title");

                entity.Property(e => e.UserId).HasColumnName("user_id");
            });

            modelBuilder.Entity<CmsUcRating>(entity =>
            {
                entity.ToTable("cms_uc_ratings");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Ip)
                    .IsRequired()
                    .HasMaxLength(16)
                    .HasColumnName("ip");

                entity.Property(e => e.ItemId).HasColumnName("item_id");

                entity.Property(e => e.Points).HasColumnName("points");
            });

            modelBuilder.Entity<CmsUcTag>(entity =>
            {
                entity.ToTable("cms_uc_tags");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ItemId).HasColumnName("item_id");

                entity.Property(e => e.Tag)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasColumnName("tag");
            });

            modelBuilder.Entity<CmsUploadImage>(entity =>
            {
                entity.ToTable("cms_upload_images");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_unicode_ci");

                entity.HasIndex(e => e.SessionId, "session_id");

                entity.HasIndex(e => e.TargetId, "target_id");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Component)
                    .IsRequired()
                    .HasMaxLength(32)
                    .HasColumnName("component");

                entity.Property(e => e.Fileurl)
                    .IsRequired()
                    .HasMaxLength(250)
                    .HasColumnName("fileurl");

                entity.Property(e => e.SessionId)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("session_id");

                entity.Property(e => e.Target)
                    .IsRequired()
                    .HasMaxLength(25)
                    .HasColumnName("target")
                    .HasDefaultValueSql("'forum'");

                entity.Property(e => e.TargetId).HasColumnName("target_id");
            });

            modelBuilder.Entity<CmsUser>(entity =>
            {
                entity.ToTable("cms_users");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_unicode_ci");

                entity.HasIndex(e => e.Birthdate, "birthdate");

                entity.HasIndex(e => e.Email, "email");

                entity.HasIndex(e => e.GroupId, "group_id");

                entity.HasIndex(e => e.InvitedBy, "invited_by");

                entity.HasIndex(e => e.Login, "login");

                entity.HasIndex(e => e.Openid, "openid");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Birthdate)
                    .HasColumnType("date")
                    .HasColumnName("birthdate")
                    .HasDefaultValueSql("'1000-01-01'");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("email");

                entity.Property(e => e.GroupId)
                    .HasColumnName("group_id")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Icq)
                    .IsRequired()
                    .HasMaxLength(15)
                    .HasColumnName("icq");

                entity.Property(e => e.Invdate)
                    .HasColumnType("datetime")
                    .HasColumnName("invdate");

                entity.Property(e => e.InvitedBy).HasColumnName("invited_by");

                entity.Property(e => e.IsDeleted).HasColumnName("is_deleted");

                entity.Property(e => e.IsLocked).HasColumnName("is_locked");

                entity.Property(e => e.IsLoggedOnce).HasColumnName("is_logged_once");

                entity.Property(e => e.LastIp)
                    .IsRequired()
                    .HasMaxLength(15)
                    .HasColumnName("last_ip");

                entity.Property(e => e.Logdate)
                    .HasColumnType("datetime")
                    .HasColumnName("logdate")
                    .HasDefaultValueSql("'1000-01-01 00:00:00'");

                entity.Property(e => e.Login)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("login");

                entity.Property(e => e.Nickname)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("nickname");

                entity.Property(e => e.Openid)
                    .HasMaxLength(250)
                    .HasColumnName("openid");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("password");

                entity.Property(e => e.Points).HasColumnName("points");

                entity.Property(e => e.Rating).HasColumnName("rating");

                entity.Property(e => e.Regdate)
                    .HasColumnType("datetime")
                    .HasColumnName("regdate")
                    .HasDefaultValueSql("'1000-01-01 00:00:00'");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("status");

                entity.Property(e => e.StatusDate)
                    .HasColumnType("datetime")
                    .HasColumnName("status_date");
            });

            modelBuilder.Entity<CmsUserAlbum>(entity =>
            {
                entity.ToTable("cms_user_albums");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_unicode_ci");

                entity.HasIndex(e => e.AllowWho, "allow_who");

                entity.HasIndex(e => e.UserId, "user_id");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AllowWho)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("allow_who");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasColumnName("description")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Pubdate)
                    .HasColumnType("datetime")
                    .HasColumnName("pubdate");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("title");

                entity.Property(e => e.UserId).HasColumnName("user_id");
            });

            modelBuilder.Entity<CmsUserAutoaward>(entity =>
            {
                entity.ToTable("cms_user_autoawards");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasColumnName("description");

                entity.Property(e => e.Imageurl)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasColumnName("imageurl");

                entity.Property(e => e.PBlog).HasColumnName("p_blog");

                entity.Property(e => e.PComment).HasColumnName("p_comment");

                entity.Property(e => e.PContent).HasColumnName("p_content");

                entity.Property(e => e.PForum).HasColumnName("p_forum");

                entity.Property(e => e.PKarma).HasColumnName("p_karma");

                entity.Property(e => e.PPhoto).HasColumnName("p_photo");

                entity.Property(e => e.PPrivphoto).HasColumnName("p_privphoto");

                entity.Property(e => e.Published)
                    .IsRequired()
                    .HasColumnName("published")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasColumnName("title");
            });

            modelBuilder.Entity<CmsUserAward>(entity =>
            {
                entity.ToTable("cms_user_awards");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_unicode_ci");

                entity.HasIndex(e => e.UserId, "user_id");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AwardId).HasColumnName("award_id");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("description");

                entity.Property(e => e.FromId).HasColumnName("from_id");

                entity.Property(e => e.Imageurl)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("imageurl");

                entity.Property(e => e.Pubdate)
                    .HasColumnType("datetime")
                    .HasColumnName("pubdate");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(250)
                    .HasColumnName("title");

                entity.Property(e => e.UserId).HasColumnName("user_id");
            });

            modelBuilder.Entity<CmsUserClub>(entity =>
            {
                entity.ToTable("cms_user_clubs");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_unicode_ci");

                entity.HasIndex(e => e.ClubId, "club_id");

                entity.HasIndex(e => e.UserId, "user_id");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ClubId).HasColumnName("club_id");

                entity.Property(e => e.Pubdate)
                    .HasColumnType("timestamp")
                    .HasColumnName("pubdate")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Role)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("role")
                    .HasDefaultValueSql("'member'");

                entity.Property(e => e.UserId).HasColumnName("user_id");
            });

            modelBuilder.Entity<CmsUserFile>(entity =>
            {
                entity.ToTable("cms_user_files");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_unicode_ci");

                entity.HasIndex(e => e.UserId, "user_id");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AllowWho)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("allow_who");

                entity.Property(e => e.Filename)
                    .IsRequired()
                    .HasMaxLength(250)
                    .HasColumnName("filename");

                entity.Property(e => e.Filesize).HasColumnName("filesize");

                entity.Property(e => e.Hits).HasColumnName("hits");

                entity.Property(e => e.Pubdate)
                    .HasColumnType("datetime")
                    .HasColumnName("pubdate");

                entity.Property(e => e.UserId).HasColumnName("user_id");
            });

            modelBuilder.Entity<CmsUserFriend>(entity =>
            {
                entity.ToTable("cms_user_friends");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_unicode_ci");

                entity.HasIndex(e => e.FromId, "from_id");

                entity.HasIndex(e => e.ToId, "to_id");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.FromId).HasColumnName("from_id");

                entity.Property(e => e.IsAccepted).HasColumnName("is_accepted");

                entity.Property(e => e.Logdate)
                    .HasColumnType("datetime")
                    .HasColumnName("logdate");

                entity.Property(e => e.ToId).HasColumnName("to_id");
            });

            modelBuilder.Entity<CmsUserGroup>(entity =>
            {
                entity.ToTable("cms_user_groups");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Access)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("access");

                entity.Property(e => e.Alias)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("alias");

                entity.Property(e => e.IsAdmin).HasColumnName("is_admin");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasColumnName("title");
            });

            modelBuilder.Entity<CmsUserGroupsAccess>(entity =>
            {
                entity.ToTable("cms_user_groups_access");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_unicode_ci");

                entity.HasIndex(e => e.AccessType, "access_type")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AccessName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("access_name");

                entity.Property(e => e.AccessType)
                    .IsRequired()
                    .HasMaxLength(60)
                    .HasColumnName("access_type");
            });

            modelBuilder.Entity<CmsUserInvite>(entity =>
            {
                entity.ToTable("cms_user_invites");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_unicode_ci");

                entity.HasIndex(e => new { e.Code, e.OwnerId, e.IsUsed }, "code");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(32)
                    .HasColumnName("code");

                entity.Property(e => e.Createdate)
                    .HasColumnType("datetime")
                    .HasColumnName("createdate");

                entity.Property(e => e.IsSended).HasColumnName("is_sended");

                entity.Property(e => e.IsUsed).HasColumnName("is_used");

                entity.Property(e => e.OwnerId).HasColumnName("owner_id");
            });

            modelBuilder.Entity<CmsUserKarma>(entity =>
            {
                entity.ToTable("cms_user_karma");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_unicode_ci");

                entity.HasIndex(e => e.UserId, "user_id");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Points).HasColumnName("points");

                entity.Property(e => e.Senddate)
                    .HasColumnType("datetime")
                    .HasColumnName("senddate");

                entity.Property(e => e.SenderId).HasColumnName("sender_id");

                entity.Property(e => e.UserId).HasColumnName("user_id");
            });

            modelBuilder.Entity<CmsUserMsg>(entity =>
            {
                entity.ToTable("cms_user_msg");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_unicode_ci");

                entity.HasIndex(e => e.FromDel, "from_del");

                entity.HasIndex(e => e.FromId, "from_id");

                entity.HasIndex(e => e.ToDel, "to_del");

                entity.HasIndex(e => e.ToId, "to_id");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.FromDel).HasColumnName("from_del");

                entity.Property(e => e.FromId).HasColumnName("from_id");

                entity.Property(e => e.IsNew)
                    .IsRequired()
                    .HasColumnName("is_new")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Message)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("message");

                entity.Property(e => e.Senddate)
                    .HasColumnType("datetime")
                    .HasColumnName("senddate");

                entity.Property(e => e.ToDel).HasColumnName("to_del");

                entity.Property(e => e.ToId).HasColumnName("to_id");
            });

            modelBuilder.Entity<CmsUserPhoto>(entity =>
            {
                entity.ToTable("cms_user_photos");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_unicode_ci");

                entity.HasIndex(e => e.AlbumId, "album_id");

                entity.HasIndex(e => e.UserId, "user_id");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AlbumId).HasColumnName("album_id");

                entity.Property(e => e.AllowWho)
                    .IsRequired()
                    .HasMaxLength(15)
                    .HasColumnName("allow_who")
                    .HasDefaultValueSql("'all'");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("description");

                entity.Property(e => e.Hits).HasColumnName("hits");

                entity.Property(e => e.Imageurl)
                    .IsRequired()
                    .HasMaxLength(250)
                    .HasColumnName("imageurl");

                entity.Property(e => e.Pubdate)
                    .HasColumnType("datetime")
                    .HasColumnName("pubdate");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(250)
                    .HasColumnName("title");

                entity.Property(e => e.UserId).HasColumnName("user_id");
            });

            modelBuilder.Entity<CmsUserProfile>(entity =>
            {
                entity.ToTable("cms_user_profiles");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_unicode_ci");

                entity.HasIndex(e => e.City, "city");

                entity.HasIndex(e => e.Description, "description")
                    .HasAnnotation("MySql:IndexPrefixLength", new[] { 333 });

                entity.HasIndex(e => e.Formsdata, "formsdata")
                    .HasAnnotation("MySql:IndexPrefixLength", new[] { 333 });

                entity.HasIndex(e => e.Gender, "gender");

                entity.HasIndex(e => e.UserId, "user_id");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AllowWho)
                    .IsRequired()
                    .HasMaxLength(35)
                    .HasColumnName("allow_who")
                    .HasDefaultValueSql("'all'");

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(250)
                    .HasColumnName("city");

                entity.Property(e => e.CmSubscribe)
                    .IsRequired()
                    .HasMaxLength(4)
                    .HasColumnName("cm_subscribe")
                    .HasDefaultValueSql("'both'");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(500)
                    .HasColumnName("description");

                entity.Property(e => e.EmailNewmsg)
                    .HasColumnName("email_newmsg")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Formsdata)
                    .IsRequired()
                    .HasMaxLength(800)
                    .HasColumnName("formsdata");

                entity.Property(e => e.Gender)
                    .IsRequired()
                    .HasMaxLength(1)
                    .HasColumnName("gender");

                entity.Property(e => e.Imageurl)
                    .IsRequired()
                    .HasMaxLength(250)
                    .HasColumnName("imageurl");

                entity.Property(e => e.Karma).HasColumnName("karma");

                entity.Property(e => e.Showbirth).HasColumnName("showbirth");

                entity.Property(e => e.Showicq).HasColumnName("showicq");

                entity.Property(e => e.Showmail).HasColumnName("showmail");

                entity.Property(e => e.Signature)
                    .IsRequired()
                    .HasMaxLength(240)
                    .HasColumnName("signature");

                entity.Property(e => e.SignatureHtml)
                    .IsRequired()
                    .HasMaxLength(300)
                    .HasColumnName("signature_html");

                entity.Property(e => e.Stats)
                    .IsRequired()
                    .HasMaxLength(500)
                    .HasColumnName("stats");

                entity.Property(e => e.UserId).HasColumnName("user_id");
            });

            modelBuilder.Entity<CmsUserWall>(entity =>
            {
                entity.ToTable("cms_user_wall");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_unicode_ci");

                entity.HasIndex(e => e.AuthorId, "author_id");

                entity.HasIndex(e => e.UserId, "user_id");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AuthorId).HasColumnName("author_id");

                entity.Property(e => e.Content)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("content");

                entity.Property(e => e.Pubdate)
                    .HasColumnType("datetime")
                    .HasColumnName("pubdate");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.Property(e => e.Usertype)
                    .IsRequired()
                    .HasMaxLength(8)
                    .HasColumnName("usertype")
                    .HasDefaultValueSql("'users'");
            });

            modelBuilder.Entity<CmsUsersActivate>(entity =>
            {
                entity.ToTable("cms_users_activate");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("code");

                entity.Property(e => e.Pubdate)
                    .HasColumnType("datetime")
                    .HasColumnName("pubdate");

                entity.Property(e => e.UserId).HasColumnName("user_id");
            });

            #endregion
        }

        //partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

        #region CMS TABLES
        public virtual DbSet<CmsAction> CmsActions { get; set; }
        public virtual DbSet<CmsActionsLog> CmsActionsLogs { get; set; }
        public virtual DbSet<CmsBanlist> CmsBanlists { get; set; }
        public virtual DbSet<CmsBanner> CmsBanners { get; set; }
        public virtual DbSet<CmsBannerHit> CmsBannerHits { get; set; }
        public virtual DbSet<CmsBlog> CmsBlogs { get; set; }
        public virtual DbSet<CmsBlogAuthor> CmsBlogAuthors { get; set; }
        public virtual DbSet<CmsBlogCat> CmsBlogCats { get; set; }
        public virtual DbSet<CmsBlogPost> CmsBlogPosts { get; set; }
        public virtual DbSet<CmsBoardCat> CmsBoardCats { get; set; }
        public virtual DbSet<CmsBoardItem> CmsBoardItems { get; set; }
        public virtual DbSet<CmsCache> CmsCaches { get; set; }
        public virtual DbSet<CmsCategory> CmsCategories { get; set; }
        public virtual DbSet<CmsClub> CmsClubs { get; set; }
        public virtual DbSet<CmsComment> CmsComments { get; set; }
        public virtual DbSet<CmsCommentTarget> CmsCommentTargets { get; set; }
        public virtual DbSet<CmsComponent> CmsComponents { get; set; }
        public virtual DbSet<CmsContent> CmsContents { get; set; }
        public virtual DbSet<CmsContentAccess> CmsContentAccesses { get; set; }
        public virtual DbSet<CmsCronJob> CmsCronJobs { get; set; }
        public virtual DbSet<CmsDownload> CmsDownloads { get; set; }
        public virtual DbSet<CmsEventHook> CmsEventHooks { get; set; }
        public virtual DbSet<CmsFaqCat> CmsFaqCats { get; set; }
        public virtual DbSet<CmsFaqQuest> CmsFaqQuests { get; set; }
        public virtual DbSet<CmsFilter> CmsFilters { get; set; }
        public virtual DbSet<CmsForm> CmsForms { get; set; }
        public virtual DbSet<CmsFormField> CmsFormFields { get; set; }
        public virtual DbSet<CmsForum> CmsForums { get; set; }
        public virtual DbSet<CmsForumCat> CmsForumCats { get; set; }
        public virtual DbSet<CmsForumFile> CmsForumFiles { get; set; }
        public virtual DbSet<CmsForumPoll> CmsForumPolls { get; set; }
        public virtual DbSet<CmsForumPost> CmsForumPosts { get; set; }
        public virtual DbSet<CmsForumThread> CmsForumThreads { get; set; }
        public virtual DbSet<CmsForumVote> CmsForumVotes { get; set; }
        public virtual DbSet<CmsGeoCity> CmsGeoCities { get; set; }
        public virtual DbSet<CmsGeoCountry> CmsGeoCountries { get; set; }
        public virtual DbSet<CmsGeoRegion> CmsGeoRegions { get; set; }
        public virtual DbSet<CmsMenu> CmsMenus { get; set; }
        public virtual DbSet<CmsModule> CmsModules { get; set; }
        public virtual DbSet<CmsModulesBind> CmsModulesBinds { get; set; }
        public virtual DbSet<CmsNsTransaction> CmsNsTransactions { get; set; }
        public virtual DbSet<CmsOnline> CmsOnlines { get; set; }
        public virtual DbSet<CmsPhotoAlbum> CmsPhotoAlbums { get; set; }
        public virtual DbSet<CmsPhotoFile> CmsPhotoFiles { get; set; }
        public virtual DbSet<CmsPlugin> CmsPlugins { get; set; }
        public virtual DbSet<CmsPoll> CmsPolls { get; set; }
        public virtual DbSet<CmsPollsLog> CmsPollsLogs { get; set; }
        public virtual DbSet<CmsRating> CmsRatings { get; set; }
        public virtual DbSet<CmsRatingTarget> CmsRatingTargets { get; set; }
        public virtual DbSet<CmsRatingsTotal> CmsRatingsTotals { get; set; }
        public virtual DbSet<CmsSearch> CmsSearches { get; set; }
        public virtual DbSet<CmsSubscribe> CmsSubscribes { get; set; }
        public virtual DbSet<CmsTag> CmsTags { get; set; }
        public virtual DbSet<CmsTagTarget> CmsTagTargets { get; set; }
        public virtual DbSet<CmsUcCart> CmsUcCarts { get; set; }
        public virtual DbSet<CmsUcCat> CmsUcCats { get; set; }
        public virtual DbSet<CmsUcCatsAccess> CmsUcCatsAccesses { get; set; }
        public virtual DbSet<CmsUcDiscount> CmsUcDiscounts { get; set; }
        public virtual DbSet<CmsUcItem> CmsUcItems { get; set; }
        public virtual DbSet<CmsUcRating> CmsUcRatings { get; set; }
        public virtual DbSet<CmsUcTag> CmsUcTags { get; set; }
        public virtual DbSet<CmsUploadImage> CmsUploadImages { get; set; }
        public virtual DbSet<CmsUser> CmsUsers { get; set; }
        public virtual DbSet<CmsUserAlbum> CmsUserAlbums { get; set; }
        public virtual DbSet<CmsUserAutoaward> CmsUserAutoawards { get; set; }
        public virtual DbSet<CmsUserAward> CmsUserAwards { get; set; }
        public virtual DbSet<CmsUserClub> CmsUserClubs { get; set; }
        public virtual DbSet<CmsUserFile> CmsUserFiles { get; set; }
        public virtual DbSet<CmsUserFriend> CmsUserFriends { get; set; }
        public virtual DbSet<CmsUserGroup> CmsUserGroups { get; set; }
        public virtual DbSet<CmsUserGroupsAccess> CmsUserGroupsAccesses { get; set; }
        public virtual DbSet<CmsUserInvite> CmsUserInvites { get; set; }
        public virtual DbSet<CmsUserKarma> CmsUserKarmas { get; set; }
        public virtual DbSet<CmsUserMsg> CmsUserMsgs { get; set; }
        public virtual DbSet<CmsUserPhoto> CmsUserPhotos { get; set; }
        public virtual DbSet<CmsUserProfile> CmsUserProfiles { get; set; }
        public virtual DbSet<CmsUserWall> CmsUserWalls { get; set; }
        public virtual DbSet<CmsUsersActivate> CmsUsersActivates { get; set; }

        #endregion
    }
}
