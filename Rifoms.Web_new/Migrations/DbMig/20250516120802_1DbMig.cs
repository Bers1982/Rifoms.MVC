using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Rifoms.Web.Migrations.DbMig
{
    public partial class _1DbMig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "app_roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NormalizedName = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ConcurrencyStamp = table.Column<string>(type: "longtext", nullable: true, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_app_roles", x => x.Id);
                },
                comment: "таблица для app_roles")
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_unicode_ci");

            migrationBuilder.CreateTable(
                name: "app_users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Password = table.Column<string>(type: "nvarchar(30)", nullable: true, comment: "колонка для хранения пароля"),
                    UserName = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NormalizedUserName = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NormalizedEmail = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EmailConfirmed = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    PasswordHash = table.Column<string>(type: "longtext", nullable: true, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SecurityStamp = table.Column<string>(type: "longtext", nullable: true, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ConcurrencyStamp = table.Column<string>(type: "longtext", nullable: true, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PhoneNumber = table.Column<string>(type: "longtext", nullable: true, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PhoneNumberConfirmed = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_app_users", x => x.Id);
                },
                comment: "таблица для app_users")
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_unicode_ci");

            migrationBuilder.CreateTable(
                name: "cms_actions",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    component = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    name = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    title = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    message = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    is_tracked = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    is_visible = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cms_actions", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_unicode_ci");

            migrationBuilder.CreateTable(
                name: "cms_actions_log",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    action_id = table.Column<int>(type: "int", nullable: false),
                    pubdate = table.Column<DateTime>(type: "datetime", nullable: false),
                    user_id = table.Column<int>(type: "int", nullable: false),
                    @object = table.Column<string>(name: "object", type: "varchar(100)", maxLength: 100, nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    object_url = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    object_id = table.Column<int>(type: "int", nullable: false),
                    target = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    target_url = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    target_id = table.Column<int>(type: "int", nullable: false),
                    description = table.Column<string>(type: "varchar(1000)", maxLength: 1000, nullable: true, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    is_friends_only = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    is_users_only = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cms_actions_log", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_unicode_ci");

            migrationBuilder.CreateTable(
                name: "cms_banlist",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    user_id = table.Column<int>(type: "int", nullable: false),
                    ip = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    bandate = table.Column<DateTime>(type: "timestamp", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    int_num = table.Column<int>(type: "int", nullable: false),
                    int_period = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    status = table.Column<bool>(type: "tinyint(1)", nullable: false, defaultValueSql: "'1'"),
                    autodelete = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    cause = table.Column<string>(type: "text", nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cms_banlist", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_unicode_ci");

            migrationBuilder.CreateTable(
                name: "cms_banner_hits",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    banner_id = table.Column<int>(type: "int", nullable: false),
                    ip = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    pubdate = table.Column<DateTime>(type: "timestamp", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cms_banner_hits", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_unicode_ci");

            migrationBuilder.CreateTable(
                name: "cms_banners",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    position = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false, defaultValueSql: "'banner_top'", collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    typeimg = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false, defaultValueSql: "'image'", collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    fileurl = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: true, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    hits = table.Column<int>(type: "int", nullable: false),
                    clicks = table.Column<int>(type: "int", nullable: false),
                    maxhits = table.Column<int>(type: "int", nullable: false),
                    maxuser = table.Column<int>(type: "int", nullable: false),
                    user_id = table.Column<int>(type: "int", nullable: false, defaultValueSql: "'1'"),
                    pubdate = table.Column<DateTime>(type: "datetime", nullable: true),
                    title = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: true, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    link = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: true, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    published = table.Column<bool>(type: "tinyint(1)", nullable: false, defaultValueSql: "'1'")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cms_banners", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_unicode_ci");

            migrationBuilder.CreateTable(
                name: "cms_blog_authors",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    user_id = table.Column<int>(type: "int", nullable: false),
                    blog_id = table.Column<int>(type: "int", nullable: false),
                    description = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    startdate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cms_blog_authors", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_unicode_ci");

            migrationBuilder.CreateTable(
                name: "cms_blog_cats",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    blog_id = table.Column<int>(type: "int", nullable: false),
                    title = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    description = table.Column<string>(type: "varchar(1000)", maxLength: 1000, nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cms_blog_cats", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_unicode_ci");

            migrationBuilder.CreateTable(
                name: "cms_blog_posts",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    user_id = table.Column<int>(type: "int", nullable: false),
                    cat_id = table.Column<int>(type: "int", nullable: false),
                    blog_id = table.Column<int>(type: "int", nullable: false),
                    pubdate = table.Column<DateTime>(type: "datetime", nullable: false),
                    title = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    feel = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    music = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    content = table.Column<string>(type: "text", nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    content_html = table.Column<string>(type: "text", nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    allow_who = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    edit_times = table.Column<int>(type: "int", nullable: false),
                    edit_date = table.Column<DateTime>(type: "timestamp", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    published = table.Column<bool>(type: "tinyint(1)", nullable: false, defaultValueSql: "'1'"),
                    seolink = table.Column<string>(type: "varchar(255)", nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    comments = table.Column<bool>(type: "tinyint(1)", nullable: false, defaultValueSql: "'1'"),
                    comments_count = table.Column<int>(type: "int", nullable: false),
                    rating = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cms_blog_posts", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_unicode_ci");

            migrationBuilder.CreateTable(
                name: "cms_blogs",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    user_id = table.Column<int>(type: "int", nullable: false),
                    title = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    pubdate = table.Column<DateTime>(type: "timestamp", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    allow_who = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    view_type = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: false, defaultValueSql: "'list'", collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    showcats = table.Column<bool>(type: "tinyint(1)", nullable: false, defaultValueSql: "'1'"),
                    ownertype = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: false, defaultValueSql: "'single'", collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    premod = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    forall = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    owner = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false, defaultValueSql: "'user'", collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    seolink = table.Column<string>(type: "varchar(255)", nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    rating = table.Column<int>(type: "int", nullable: false),
                    comments_count = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cms_blogs", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_unicode_ci");

            migrationBuilder.CreateTable(
                name: "cms_board_cats",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    parent_id = table.Column<int>(type: "int", nullable: false),
                    ordering = table.Column<int>(type: "int", nullable: false, defaultValueSql: "'1'"),
                    NSLeft = table.Column<int>(type: "int", nullable: false),
                    NSRight = table.Column<int>(type: "int", nullable: false),
                    NSDiffer = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NSIgnore = table.Column<int>(type: "int", nullable: false),
                    NSLevel = table.Column<int>(type: "int", nullable: false),
                    title = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    description = table.Column<string>(type: "varchar(300)", maxLength: 300, nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    published = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    orderform = table.Column<bool>(type: "tinyint(1)", nullable: true, defaultValueSql: "'1'"),
                    showdate = table.Column<bool>(type: "tinyint(1)", nullable: false, defaultValueSql: "'1'"),
                    pubdate = table.Column<DateTime>(type: "datetime", nullable: false),
                    orderby = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false, defaultValueSql: "'title'", collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    orderto = table.Column<string>(type: "varchar(4)", maxLength: 4, nullable: false, defaultValueSql: "'asc'", collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    @public = table.Column<bool>(name: "public", type: "tinyint(1)", nullable: false),
                    perpage = table.Column<int>(type: "int", nullable: false, defaultValueSql: "'15'"),
                    maxcols = table.Column<int>(type: "int", nullable: false, defaultValueSql: "'1'"),
                    thumb1 = table.Column<int>(type: "int", nullable: false, defaultValueSql: "'64'"),
                    thumb2 = table.Column<int>(type: "int", nullable: false, defaultValueSql: "'400'"),
                    thumbsqr = table.Column<int>(type: "int", nullable: false),
                    uplimit = table.Column<int>(type: "int", nullable: false, defaultValueSql: "'10'"),
                    is_photos = table.Column<bool>(type: "tinyint(1)", nullable: false, defaultValueSql: "'1'"),
                    icon = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true, defaultValueSql: "'folder_grey.png'", collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    obtypes = table.Column<string>(type: "text", nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    form_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cms_board_cats", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_unicode_ci");

            migrationBuilder.CreateTable(
                name: "cms_board_items",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    category_id = table.Column<int>(type: "int", nullable: false),
                    user_id = table.Column<int>(type: "int", nullable: false),
                    obtype = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    title = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    content = table.Column<string>(type: "text", nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    formsdata = table.Column<string>(type: "text", nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    city = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    pubdate = table.Column<DateTime>(type: "timestamp", nullable: true, defaultValueSql: "CURRENT_TIMESTAMP"),
                    pubdays = table.Column<int>(type: "int", nullable: false),
                    published = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    file = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    more_images = table.Column<string>(type: "text", nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    hits = table.Column<uint>(type: "int unsigned", nullable: false),
                    is_vip = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    vipdate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ip = table.Column<uint>(type: "int unsigned", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cms_board_items", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_unicode_ci");

            migrationBuilder.CreateTable(
                name: "cms_cache",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    target = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    target_id = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    cachedate = table.Column<DateTime>(type: "datetime", nullable: false),
                    cachefile = table.Column<string>(type: "varchar(80)", maxLength: 80, nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cms_cache", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_unicode_ci");

            migrationBuilder.CreateTable(
                name: "cms_category",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    parent_id = table.Column<int>(type: "int", nullable: true),
                    title = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    description = table.Column<string>(type: "text", nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    published = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    showdate = table.Column<bool>(type: "tinyint(1)", nullable: false, defaultValueSql: "'1'"),
                    showcomm = table.Column<bool>(type: "tinyint(1)", nullable: false, defaultValueSql: "'1'"),
                    orderby = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false, defaultValueSql: "'date'", collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    orderto = table.Column<string>(type: "varchar(4)", maxLength: 4, nullable: false, defaultValueSql: "'asc'", collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    modgrp_id = table.Column<int>(type: "int", nullable: false),
                    NSLeft = table.Column<int>(type: "int", nullable: false),
                    NSRight = table.Column<int>(type: "int", nullable: false),
                    NSLevel = table.Column<int>(type: "int", nullable: false),
                    NSDiffer = table.Column<string>(type: "varchar(11)", maxLength: 11, nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NSIgnore = table.Column<int>(type: "int", nullable: false),
                    ordering = table.Column<int>(type: "int", nullable: false),
                    maxcols = table.Column<int>(type: "int", nullable: false, defaultValueSql: "'1'"),
                    showtags = table.Column<bool>(type: "tinyint(1)", nullable: false, defaultValueSql: "'1'"),
                    showrss = table.Column<bool>(type: "tinyint(1)", nullable: false, defaultValueSql: "'1'"),
                    showdesc = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    is_public = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    photoalbum = table.Column<string>(type: "text", nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    seolink = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    url = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tpl = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false, defaultValueSql: "'com_content_view.tpl'", collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    cost = table.Column<string>(type: "varchar(5)", maxLength: 5, nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cms_category", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_unicode_ci");

            migrationBuilder.CreateTable(
                name: "cms_clubs",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    admin_id = table.Column<int>(type: "int", nullable: false, defaultValueSql: "'1'"),
                    title = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    description = table.Column<string>(type: "longtext", nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    imageurl = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    pubdate = table.Column<DateTime>(type: "timestamp", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    clubtype = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: false, defaultValueSql: "'public'", collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    published = table.Column<bool>(type: "tinyint(1)", nullable: false, defaultValueSql: "'1'"),
                    maxsize = table.Column<int>(type: "int", nullable: false),
                    enabled_blogs = table.Column<bool>(type: "tinyint(1)", nullable: true, defaultValueSql: "'-1'"),
                    enabled_photos = table.Column<bool>(type: "tinyint(1)", nullable: true, defaultValueSql: "'-1'"),
                    rating = table.Column<int>(type: "int", nullable: false),
                    members_count = table.Column<int>(type: "int", nullable: false, defaultValueSql: "'1'"),
                    photo_premod = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    blog_premod = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    blog_min_karma = table.Column<int>(type: "int", nullable: false),
                    photo_min_karma = table.Column<int>(type: "int", nullable: false),
                    album_min_karma = table.Column<int>(type: "int", nullable: false, defaultValueSql: "'25'"),
                    join_min_karma = table.Column<int>(type: "int", nullable: false),
                    join_karma_limit = table.Column<int>(type: "int", nullable: false),
                    create_karma = table.Column<int>(type: "int", nullable: false),
                    is_vip = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    join_cost = table.Column<float>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cms_clubs", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_unicode_ci");

            migrationBuilder.CreateTable(
                name: "cms_comment_targets",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    target = table.Column<string>(type: "varchar(32)", maxLength: 32, nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    component = table.Column<string>(type: "varchar(32)", maxLength: 32, nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    title = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    target_table = table.Column<string>(type: "varchar(32)", maxLength: 32, nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    subj = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cms_comment_targets", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_unicode_ci");

            migrationBuilder.CreateTable(
                name: "cms_comments",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    parent_id = table.Column<int>(type: "int", nullable: false),
                    pid = table.Column<int>(type: "int", nullable: false),
                    user_id = table.Column<int>(type: "int", nullable: false),
                    target = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    target_id = table.Column<int>(type: "int", nullable: false),
                    guestname = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    content = table.Column<string>(type: "text", nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    content_bbcode = table.Column<string>(type: "text", nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    pubdate = table.Column<DateTime>(type: "timestamp", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    published = table.Column<bool>(type: "tinyint(1)", nullable: false, defaultValueSql: "'1'"),
                    is_new = table.Column<bool>(type: "tinyint(1)", nullable: false, defaultValueSql: "'1'"),
                    target_title = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    target_link = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ip = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    is_hidden = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    rating = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cms_comments", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_unicode_ci");

            migrationBuilder.CreateTable(
                name: "cms_components",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    title = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    link = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    config = table.Column<string>(type: "text", nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    @internal = table.Column<int>(name: "internal", type: "int", nullable: false),
                    author = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false, defaultValueSql: "'InstantCMS team'", collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    published = table.Column<bool>(type: "tinyint(1)", nullable: false, defaultValueSql: "'1'"),
                    version = table.Column<string>(type: "varchar(6)", maxLength: 6, nullable: false, defaultValueSql: "'1.10.3'", collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    system = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cms_components", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_unicode_ci");

            migrationBuilder.CreateTable(
                name: "cms_content",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    category_id = table.Column<int>(type: "int", nullable: false),
                    user_id = table.Column<int>(type: "int", nullable: false, defaultValueSql: "'1'"),
                    pubdate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "'1000-01-01 00:00:00'"),
                    enddate = table.Column<DateTime>(type: "date", nullable: false),
                    is_end = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    title = table.Column<string>(type: "varchar(1000)", maxLength: 1000, nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    description = table.Column<string>(type: "text", nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    content = table.Column<string>(type: "longtext", nullable: true, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    published = table.Column<bool>(type: "tinyint(1)", nullable: false, defaultValueSql: "'1'"),
                    hits = table.Column<int>(type: "int", nullable: false),
                    rating = table.Column<int>(type: "int", nullable: false),
                    meta_desc = table.Column<string>(type: "text", nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    meta_keys = table.Column<string>(type: "text", nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    showtitle = table.Column<bool>(type: "tinyint(1)", nullable: false, defaultValueSql: "'1'"),
                    showdate = table.Column<bool>(type: "tinyint(1)", nullable: false, defaultValueSql: "'1'"),
                    showlatest = table.Column<bool>(type: "tinyint(1)", nullable: false, defaultValueSql: "'1'"),
                    showpath = table.Column<bool>(type: "tinyint(1)", nullable: false, defaultValueSql: "'1'"),
                    ordering = table.Column<int>(type: "int", nullable: false),
                    comments = table.Column<bool>(type: "tinyint(1)", nullable: false, defaultValueSql: "'1'"),
                    is_arhive = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    seolink = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    canrate = table.Column<bool>(type: "tinyint(1)", nullable: false, defaultValueSql: "'1'"),
                    pagetitle = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    url = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tpl = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false, defaultValueSql: "'com_content_read.tpl'", collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cms_content", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_unicode_ci");

            migrationBuilder.CreateTable(
                name: "cms_content_access",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    content_id = table.Column<int>(type: "int", nullable: false),
                    content_type = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    group_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cms_content_access", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_unicode_ci");

            migrationBuilder.CreateTable(
                name: "cms_cron_jobs",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    job_name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    job_interval = table.Column<short>(type: "smallint", nullable: false, defaultValueSql: "'1'"),
                    job_run_date = table.Column<DateTime>(type: "timestamp", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    component = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    model_method = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    custom_file = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    is_enabled = table.Column<bool>(type: "tinyint(1)", nullable: false, defaultValueSql: "'1'"),
                    is_new = table.Column<short>(type: "smallint", nullable: false, defaultValueSql: "'1'"),
                    comment = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    class_name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    class_method = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cms_cron_jobs", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_unicode_ci");

            migrationBuilder.CreateTable(
                name: "cms_downloads",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    fileurl = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    hits = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cms_downloads", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_unicode_ci");

            migrationBuilder.CreateTable(
                name: "cms_event_hooks",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    @event = table.Column<string>(name: "event", type: "varchar(50)", maxLength: 50, nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    plugin_id = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cms_event_hooks", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_unicode_ci");

            migrationBuilder.CreateTable(
                name: "cms_faq_cats",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    parent_id = table.Column<int>(type: "int", nullable: false),
                    title = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    description = table.Column<string>(type: "text", nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    published = table.Column<bool>(type: "tinyint(1)", nullable: false, defaultValueSql: "'1'")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cms_faq_cats", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_unicode_ci");

            migrationBuilder.CreateTable(
                name: "cms_faq_quests",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    category_id = table.Column<int>(type: "int", nullable: false),
                    pubdate = table.Column<DateTime>(type: "datetime", nullable: false),
                    published = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    quest = table.Column<string>(type: "text", nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    answer = table.Column<string>(type: "text", nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    user_id = table.Column<int>(type: "int", nullable: false),
                    answeruser_id = table.Column<int>(type: "int", nullable: false),
                    answerdate = table.Column<DateTime>(type: "datetime", nullable: false),
                    hits = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cms_faq_quests", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_unicode_ci");

            migrationBuilder.CreateTable(
                name: "cms_filters",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    title = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    description = table.Column<string>(type: "text", nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    link = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    published = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cms_filters", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_unicode_ci");

            migrationBuilder.CreateTable(
                name: "cms_form_fields",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    form_id = table.Column<int>(type: "int", nullable: false),
                    title = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    description = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false, defaultValueSql: "''", collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ordering = table.Column<int>(type: "int", nullable: false),
                    kind = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    mustbe = table.Column<int>(type: "int", nullable: false),
                    config = table.Column<string>(type: "text", nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cms_form_fields", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_unicode_ci");

            migrationBuilder.CreateTable(
                name: "cms_forms",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    title = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    description = table.Column<string>(type: "text", nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    email = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    sendto = table.Column<string>(type: "varchar(4)", maxLength: 4, nullable: false, defaultValueSql: "'mail'", collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    user_id = table.Column<int>(type: "int", nullable: false, defaultValueSql: "'1'"),
                    form_action = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false, defaultValueSql: "'/forms/process'", collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tpl = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false, defaultValueSql: "'form'", collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    only_fields = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    showtitle = table.Column<bool>(type: "tinyint(1)", nullable: false, defaultValueSql: "'1'")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cms_forms", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_unicode_ci");

            migrationBuilder.CreateTable(
                name: "cms_forum_cats",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    title = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    published = table.Column<bool>(type: "tinyint(1)", nullable: false, defaultValueSql: "'1'"),
                    ordering = table.Column<int>(type: "int", nullable: false),
                    seolink = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cms_forum_cats", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_unicode_ci");

            migrationBuilder.CreateTable(
                name: "cms_forum_files",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    post_id = table.Column<int>(type: "int", nullable: false),
                    filename = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    filesize = table.Column<int>(type: "int", nullable: false),
                    hits = table.Column<int>(type: "int", nullable: false),
                    pubdate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cms_forum_files", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_unicode_ci");

            migrationBuilder.CreateTable(
                name: "cms_forum_polls",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    thread_id = table.Column<int>(type: "int", nullable: false),
                    title = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    description = table.Column<string>(type: "text", nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    answers = table.Column<string>(type: "text", nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    options = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    enddate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cms_forum_polls", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_unicode_ci");

            migrationBuilder.CreateTable(
                name: "cms_forum_posts",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    thread_id = table.Column<int>(type: "int", nullable: false),
                    user_id = table.Column<int>(type: "int", nullable: false),
                    pinned = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    pubdate = table.Column<DateTime>(type: "datetime", nullable: false),
                    editdate = table.Column<DateTime>(type: "datetime", nullable: false),
                    edittimes = table.Column<int>(type: "int", nullable: false),
                    rating = table.Column<int>(type: "int", nullable: false),
                    attach_count = table.Column<int>(type: "int", nullable: false),
                    content = table.Column<string>(type: "text", nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    content_html = table.Column<string>(type: "text", nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cms_forum_posts", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_unicode_ci");

            migrationBuilder.CreateTable(
                name: "cms_forum_threads",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    forum_id = table.Column<int>(type: "int", nullable: false),
                    user_id = table.Column<int>(type: "int", nullable: false),
                    title = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    description = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    icon = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    pubdate = table.Column<DateTime>(type: "datetime", nullable: false),
                    hits = table.Column<int>(type: "int", nullable: false),
                    closed = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    pinned = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    is_hidden = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    rel_to = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    rel_id = table.Column<int>(type: "int", nullable: false),
                    post_count = table.Column<int>(type: "int", nullable: false),
                    last_msg = table.Column<string>(type: "text", nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cms_forum_threads", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_unicode_ci");

            migrationBuilder.CreateTable(
                name: "cms_forum_votes",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    poll_id = table.Column<int>(type: "int", nullable: false),
                    answer = table.Column<string>(type: "varchar(300)", maxLength: 300, nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    user_id = table.Column<int>(type: "int", nullable: false),
                    pubdate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cms_forum_votes", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_unicode_ci");

            migrationBuilder.CreateTable(
                name: "cms_forums",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    category_id = table.Column<int>(type: "int", nullable: false),
                    title = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    description = table.Column<string>(type: "varchar(300)", maxLength: 300, nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    access_list = table.Column<string>(type: "tinytext", nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    moder_list = table.Column<string>(type: "tinytext", nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ordering = table.Column<int>(type: "int", nullable: false),
                    published = table.Column<bool>(type: "tinyint(1)", nullable: false, defaultValueSql: "'1'"),
                    parent_id = table.Column<int>(type: "int", nullable: false),
                    NSLeft = table.Column<int>(type: "int", nullable: false),
                    NSRight = table.Column<int>(type: "int", nullable: false),
                    NSDiffer = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NSIgnore = table.Column<int>(type: "int", nullable: false),
                    NSLevel = table.Column<int>(type: "int", nullable: false),
                    icon = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    topic_cost = table.Column<float>(type: "float", nullable: false),
                    thread_count = table.Column<int>(type: "int", nullable: false),
                    post_count = table.Column<int>(type: "int", nullable: false),
                    last_msg = table.Column<string>(type: "text", nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cms_forums", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_unicode_ci");

            migrationBuilder.CreateTable(
                name: "cms_geo_cities",
                columns: table => new
                {
                    id = table.Column<uint>(type: "int unsigned", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    country_id = table.Column<uint>(type: "int unsigned", nullable: false),
                    region_id = table.Column<uint>(type: "int unsigned", nullable: false),
                    name = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false, defaultValueSql: "''", collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cms_geo_cities", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_unicode_ci");

            migrationBuilder.CreateTable(
                name: "cms_geo_countries",
                columns: table => new
                {
                    id = table.Column<uint>(type: "int unsigned", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false, defaultValueSql: "''", collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    alpha2 = table.Column<string>(type: "char(2)", fixedLength: true, maxLength: 2, nullable: false, defaultValueSql: "''", collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    alpha3 = table.Column<string>(type: "char(3)", fixedLength: true, maxLength: 3, nullable: false, defaultValueSql: "''", collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    iso = table.Column<int>(type: "int", nullable: false),
                    ordering = table.Column<int>(type: "int", nullable: false, defaultValueSql: "'100'")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cms_geo_countries", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_unicode_ci");

            migrationBuilder.CreateTable(
                name: "cms_geo_regions",
                columns: table => new
                {
                    id = table.Column<uint>(type: "int unsigned", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    country_id = table.Column<uint>(type: "int unsigned", nullable: false),
                    name = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: false, defaultValueSql: "''", collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cms_geo_regions", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_unicode_ci");

            migrationBuilder.CreateTable(
                name: "cms_menu",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    menu = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    title = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    link = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    linktype = table.Column<string>(type: "varchar(12)", maxLength: 12, nullable: false, defaultValueSql: "'link'", collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    linkid = table.Column<string>(type: "varchar(25)", maxLength: 25, nullable: true, defaultValueSql: "'-1'", collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    target = table.Column<string>(type: "varchar(8)", maxLength: 8, nullable: false, defaultValueSql: "'_self'", collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    component = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ordering = table.Column<int>(type: "int", nullable: false, defaultValueSql: "'1'"),
                    published = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    template = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    access_list = table.Column<string>(type: "tinytext", nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    iconurl = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NSLeft = table.Column<int>(type: "int", nullable: false),
                    NSRight = table.Column<int>(type: "int", nullable: false),
                    NSLevel = table.Column<int>(type: "int", nullable: false),
                    NSDiffer = table.Column<string>(type: "varchar(40)", maxLength: 40, nullable: true, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NSIgnore = table.Column<int>(type: "int", nullable: false),
                    parent_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cms_menu", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_unicode_ci");

            migrationBuilder.CreateTable(
                name: "cms_modules",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    position = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    name = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    title = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    is_external = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    content = table.Column<string>(type: "text", nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ordering = table.Column<int>(type: "int", nullable: false, defaultValueSql: "'1'"),
                    showtitle = table.Column<int>(type: "int", nullable: false, defaultValueSql: "'1'"),
                    published = table.Column<bool>(type: "tinyint(1)", nullable: false, defaultValueSql: "'1'"),
                    user = table.Column<int>(type: "int", nullable: false),
                    config = table.Column<string>(type: "text", nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    original = table.Column<int>(type: "int", nullable: false, defaultValueSql: "'1'"),
                    css_prefix = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    access_list = table.Column<string>(type: "tinytext", nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    cache = table.Column<int>(type: "int", nullable: false),
                    cachetime = table.Column<int>(type: "int", nullable: false, defaultValueSql: "'1'"),
                    cacheint = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: false, defaultValueSql: "'HOUR'", collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    template = table.Column<string>(type: "varchar(35)", maxLength: 35, nullable: false, defaultValueSql: "'module.tpl'", collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    is_strict_bind = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    author = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false, defaultValueSql: "'InstantCMS team'", collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    version = table.Column<string>(type: "varchar(6)", maxLength: 6, nullable: false, defaultValueSql: "'1.0'", collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cms_modules", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_unicode_ci");

            migrationBuilder.CreateTable(
                name: "cms_modules_bind",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    module_id = table.Column<int>(type: "int", nullable: false),
                    menu_id = table.Column<int>(type: "int", nullable: false),
                    position = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cms_modules_bind", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_unicode_ci");

            migrationBuilder.CreateTable(
                name: "cms_ns_transactions",
                columns: table => new
                {
                    IDTransaction = table.Column<uint>(type: "int unsigned", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    TableName = table.Column<string>(type: "tinytext", nullable: true, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Differ = table.Column<string>(type: "tinytext", nullable: true, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    InTransaction = table.Column<ulong>(type: "bit(1)", nullable: true),
                    TStamp = table.Column<DateTime>(type: "timestamp", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.IDTransaction);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_unicode_ci");

            migrationBuilder.CreateTable(
                name: "cms_online",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ip = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    sess_id = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    lastdate = table.Column<DateTime>(type: "timestamp", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    user_id = table.Column<int>(type: "int", nullable: false),
                    agent = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    viewurl = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cms_online", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_unicode_ci");

            migrationBuilder.CreateTable(
                name: "cms_photo_albums",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    parent_id = table.Column<int>(type: "int", nullable: false),
                    ordering = table.Column<int>(type: "int", nullable: false, defaultValueSql: "'1'"),
                    NSLeft = table.Column<int>(type: "int", nullable: false),
                    NSRight = table.Column<int>(type: "int", nullable: false),
                    NSDiffer = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NSIgnore = table.Column<int>(type: "int", nullable: false),
                    NSLevel = table.Column<int>(type: "int", nullable: false),
                    title = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    description = table.Column<string>(type: "varchar(300)", maxLength: 300, nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    published = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    showdate = table.Column<bool>(type: "tinyint(1)", nullable: false, defaultValueSql: "'1'"),
                    iconurl = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    pubdate = table.Column<DateTime>(type: "timestamp", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    orderby = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false, defaultValueSql: "'title'", collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    orderto = table.Column<string>(type: "varchar(4)", maxLength: 4, nullable: false, defaultValueSql: "'asc'", collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    @public = table.Column<bool>(name: "public", type: "tinyint(1)", nullable: false),
                    perpage = table.Column<int>(type: "int", nullable: false, defaultValueSql: "'15'"),
                    cssprefix = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    thumb1 = table.Column<int>(type: "int", nullable: false, defaultValueSql: "'96'"),
                    thumb2 = table.Column<int>(type: "int", nullable: false, defaultValueSql: "'480'"),
                    thumbsqr = table.Column<bool>(type: "tinyint(1)", nullable: false, defaultValueSql: "'1'"),
                    showtype = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false, defaultValueSql: "'lightbox'", collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    nav = table.Column<bool>(type: "tinyint(1)", nullable: false, defaultValueSql: "'1'"),
                    uplimit = table.Column<int>(type: "int", nullable: false),
                    maxcols = table.Column<int>(type: "int", nullable: false, defaultValueSql: "'4'"),
                    orderform = table.Column<bool>(type: "tinyint(1)", nullable: false, defaultValueSql: "'1'"),
                    showtags = table.Column<bool>(type: "tinyint(1)", nullable: false, defaultValueSql: "'1'"),
                    bbcode = table.Column<bool>(type: "tinyint(1)", nullable: false, defaultValueSql: "'1'"),
                    user_id = table.Column<int>(type: "int", nullable: false, defaultValueSql: "'1'"),
                    is_comments = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cms_photo_albums", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_unicode_ci");

            migrationBuilder.CreateTable(
                name: "cms_photo_files",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    album_id = table.Column<int>(type: "int", nullable: false),
                    title = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    description = table.Column<string>(type: "text", nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    pubdate = table.Column<DateTime>(type: "timestamp", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    file = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    published = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    hits = table.Column<int>(type: "int", nullable: false),
                    showdate = table.Column<bool>(type: "tinyint(1)", nullable: false, defaultValueSql: "'1'"),
                    comments = table.Column<bool>(type: "tinyint(1)", nullable: false, defaultValueSql: "'1'"),
                    user_id = table.Column<int>(type: "int", nullable: false, defaultValueSql: "'1'"),
                    owner = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: true, defaultValueSql: "'photos'", collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    rating = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cms_photo_files", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_unicode_ci");

            migrationBuilder.CreateTable(
                name: "cms_plugins",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    plugin = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    title = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    description = table.Column<string>(type: "text", nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    author = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    version = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    plugin_type = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    published = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    config = table.Column<string>(type: "text", nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cms_plugins", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_unicode_ci");

            migrationBuilder.CreateTable(
                name: "cms_polls",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    title = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    pubdate = table.Column<DateTime>(type: "timestamp", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    answers = table.Column<string>(type: "text", nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cms_polls", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_unicode_ci");

            migrationBuilder.CreateTable(
                name: "cms_polls_log",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    poll_id = table.Column<int>(type: "int", nullable: false),
                    answer = table.Column<string>(type: "varchar(300)", maxLength: 300, nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    user_id = table.Column<int>(type: "int", nullable: false),
                    ip = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cms_polls_log", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_unicode_ci");

            migrationBuilder.CreateTable(
                name: "cms_rating_targets",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    target = table.Column<string>(type: "varchar(32)", maxLength: 32, nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    component = table.Column<string>(type: "varchar(32)", maxLength: 32, nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    is_user_affect = table.Column<sbyte>(type: "tinyint", nullable: false),
                    user_weight = table.Column<short>(type: "smallint", nullable: false),
                    target_table = table.Column<string>(type: "varchar(32)", maxLength: 32, nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    target_title = table.Column<string>(type: "varchar(70)", maxLength: 70, nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cms_rating_targets", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_unicode_ci");

            migrationBuilder.CreateTable(
                name: "cms_ratings",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    item_id = table.Column<int>(type: "int", nullable: false),
                    points = table.Column<int>(type: "int", nullable: false),
                    ip = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    target = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    user_id = table.Column<int>(type: "int", nullable: false, defaultValueSql: "'1'"),
                    pubdate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cms_ratings", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_unicode_ci");

            migrationBuilder.CreateTable(
                name: "cms_ratings_total",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    target = table.Column<string>(type: "varchar(32)", maxLength: 32, nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    item_id = table.Column<int>(type: "mediumint", nullable: false),
                    total_rating = table.Column<int>(type: "int", nullable: false),
                    total_votes = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cms_ratings_total", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_unicode_ci");

            migrationBuilder.CreateTable(
                name: "cms_search",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    session_id = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    date = table.Column<DateTime>(type: "timestamp", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    pubdate = table.Column<DateTime>(type: "datetime", nullable: true),
                    title = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    description = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    link = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    place = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    placelink = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cms_search", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_unicode_ci");

            migrationBuilder.CreateTable(
                name: "cms_subscribe",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    user_id = table.Column<int>(type: "int", nullable: false),
                    target = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    target_id = table.Column<int>(type: "int", nullable: false),
                    pubdate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cms_subscribe", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_unicode_ci");

            migrationBuilder.CreateTable(
                name: "cms_tag_targets",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    target = table.Column<string>(type: "varchar(32)", maxLength: 32, nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    component = table.Column<string>(type: "varchar(32)", maxLength: 32, nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    title = table.Column<string>(type: "varchar(70)", maxLength: 70, nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cms_tag_targets", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_unicode_ci");

            migrationBuilder.CreateTable(
                name: "cms_tags",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    tag = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    target = table.Column<string>(type: "varchar(25)", maxLength: 25, nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    item_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cms_tags", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_unicode_ci");

            migrationBuilder.CreateTable(
                name: "cms_uc_cart",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    user_id = table.Column<int>(type: "int", nullable: false),
                    session_id = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    item_id = table.Column<int>(type: "int", nullable: false),
                    pubdate = table.Column<DateTime>(type: "datetime", nullable: false),
                    itemscount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cms_uc_cart", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_unicode_ci");

            migrationBuilder.CreateTable(
                name: "cms_uc_cats",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    parent_id = table.Column<int>(type: "int", nullable: false),
                    title = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    description = table.Column<string>(type: "text", nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    published = table.Column<bool>(type: "tinyint(1)", nullable: false, defaultValueSql: "'1'"),
                    fieldsstruct = table.Column<string>(type: "text", nullable: true, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    view_type = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false, defaultValueSql: "'list'", collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    fields_show = table.Column<int>(type: "int", nullable: false, defaultValueSql: "'10'"),
                    showmore = table.Column<bool>(type: "tinyint(1)", nullable: false, defaultValueSql: "'1'"),
                    perpage = table.Column<int>(type: "int", nullable: false, defaultValueSql: "'20'"),
                    showtags = table.Column<bool>(type: "tinyint(1)", nullable: false, defaultValueSql: "'1'"),
                    showsort = table.Column<bool>(type: "tinyint(1)", nullable: false, defaultValueSql: "'1'"),
                    is_ratings = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    orderby = table.Column<string>(type: "varchar(12)", maxLength: 12, nullable: false, defaultValueSql: "'pubdate'", collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    orderto = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: true, defaultValueSql: "'desc'", collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    showabc = table.Column<bool>(type: "tinyint(1)", nullable: false, defaultValueSql: "'1'"),
                    shownew = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    newint = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    filters = table.Column<int>(type: "int", nullable: false),
                    is_shop = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    NSLeft = table.Column<int>(type: "int", nullable: false),
                    NSRight = table.Column<int>(type: "int", nullable: false),
                    NSLevel = table.Column<int>(type: "int", nullable: false),
                    NSDiffer = table.Column<int>(type: "int", nullable: false),
                    NSIgnore = table.Column<int>(type: "int", nullable: false),
                    ordering = table.Column<int>(type: "int", nullable: false),
                    is_public = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    can_edit = table.Column<int>(type: "int", nullable: false),
                    cost = table.Column<string>(type: "varchar(5)", maxLength: 5, nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cms_uc_cats", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_unicode_ci");

            migrationBuilder.CreateTable(
                name: "cms_uc_cats_access",
                columns: table => new
                {
                    cat_id = table.Column<int>(type: "int", nullable: false),
                    group_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_unicode_ci");

            migrationBuilder.CreateTable(
                name: "cms_uc_discount",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    title = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    cat_id = table.Column<int>(type: "int", nullable: false),
                    sign = table.Column<sbyte>(type: "tinyint", nullable: false),
                    value = table.Column<float>(type: "float", nullable: false),
                    unit = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    if_limit = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cms_uc_discount", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_unicode_ci");

            migrationBuilder.CreateTable(
                name: "cms_uc_items",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    category_id = table.Column<int>(type: "int", nullable: false),
                    title = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    pubdate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "'1000-01-01 00:00:00'"),
                    published = table.Column<bool>(type: "tinyint(1)", nullable: false, defaultValueSql: "'1'"),
                    imageurl = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    fieldsdata = table.Column<string>(type: "text", nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    hits = table.Column<int>(type: "int", nullable: false),
                    is_comments = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    tags = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    rating = table.Column<float>(type: "float", nullable: false),
                    meta_desc = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    meta_keys = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    price = table.Column<float>(type: "float", nullable: false),
                    canmany = table.Column<int>(type: "int", nullable: false, defaultValueSql: "'1'"),
                    user_id = table.Column<int>(type: "int", nullable: false),
                    on_moderate = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cms_uc_items", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_unicode_ci");

            migrationBuilder.CreateTable(
                name: "cms_uc_ratings",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    item_id = table.Column<int>(type: "int", nullable: false),
                    points = table.Column<int>(type: "int", nullable: false),
                    ip = table.Column<string>(type: "varchar(16)", maxLength: 16, nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cms_uc_ratings", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_unicode_ci");

            migrationBuilder.CreateTable(
                name: "cms_uc_tags",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    tag = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    item_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cms_uc_tags", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_unicode_ci");

            migrationBuilder.CreateTable(
                name: "cms_upload_images",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    target_id = table.Column<int>(type: "int", nullable: false),
                    session_id = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    fileurl = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    target = table.Column<string>(type: "varchar(25)", maxLength: 25, nullable: false, defaultValueSql: "'forum'", collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    component = table.Column<string>(type: "varchar(32)", maxLength: 32, nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cms_upload_images", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_unicode_ci");

            migrationBuilder.CreateTable(
                name: "cms_user_albums",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    user_id = table.Column<int>(type: "int", nullable: false),
                    title = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    pubdate = table.Column<DateTime>(type: "datetime", nullable: false),
                    allow_who = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    description = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false, defaultValueSql: "''", collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cms_user_albums", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_unicode_ci");

            migrationBuilder.CreateTable(
                name: "cms_user_autoawards",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    title = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    description = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    imageurl = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    p_comment = table.Column<int>(type: "int", nullable: false),
                    p_blog = table.Column<int>(type: "int", nullable: false),
                    p_forum = table.Column<int>(type: "int", nullable: false),
                    p_photo = table.Column<int>(type: "int", nullable: false),
                    p_privphoto = table.Column<int>(type: "int", nullable: true),
                    p_content = table.Column<int>(type: "int", nullable: false),
                    p_karma = table.Column<int>(type: "int", nullable: false),
                    published = table.Column<bool>(type: "tinyint(1)", nullable: false, defaultValueSql: "'1'")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cms_user_autoawards", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_unicode_ci");

            migrationBuilder.CreateTable(
                name: "cms_user_awards",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    user_id = table.Column<int>(type: "int", nullable: false),
                    pubdate = table.Column<DateTime>(type: "datetime", nullable: false),
                    title = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    description = table.Column<string>(type: "text", nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    imageurl = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    from_id = table.Column<int>(type: "int", nullable: false),
                    award_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cms_user_awards", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_unicode_ci");

            migrationBuilder.CreateTable(
                name: "cms_user_clubs",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    user_id = table.Column<int>(type: "int", nullable: false),
                    club_id = table.Column<int>(type: "int", nullable: false),
                    role = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false, defaultValueSql: "'member'", collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    pubdate = table.Column<DateTime>(type: "timestamp", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cms_user_clubs", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_unicode_ci");

            migrationBuilder.CreateTable(
                name: "cms_user_files",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    user_id = table.Column<int>(type: "int", nullable: false),
                    filename = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    pubdate = table.Column<DateTime>(type: "datetime", nullable: false),
                    allow_who = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    filesize = table.Column<int>(type: "int", nullable: false),
                    hits = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cms_user_files", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_unicode_ci");

            migrationBuilder.CreateTable(
                name: "cms_user_friends",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    to_id = table.Column<int>(type: "int", nullable: false),
                    from_id = table.Column<int>(type: "int", nullable: false),
                    logdate = table.Column<DateTime>(type: "datetime", nullable: false),
                    is_accepted = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cms_user_friends", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_unicode_ci");

            migrationBuilder.CreateTable(
                name: "cms_user_groups",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    title = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    alias = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    is_admin = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    access = table.Column<string>(type: "text", nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cms_user_groups", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_unicode_ci");

            migrationBuilder.CreateTable(
                name: "cms_user_groups_access",
                columns: table => new
                {
                    id = table.Column<uint>(type: "int unsigned", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    access_type = table.Column<string>(type: "varchar(60)", maxLength: 60, nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    access_name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cms_user_groups_access", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_unicode_ci");

            migrationBuilder.CreateTable(
                name: "cms_user_invites",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    code = table.Column<string>(type: "varchar(32)", maxLength: 32, nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    owner_id = table.Column<int>(type: "int", nullable: false),
                    createdate = table.Column<DateTime>(type: "datetime", nullable: false),
                    is_used = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    is_sended = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cms_user_invites", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_unicode_ci");

            migrationBuilder.CreateTable(
                name: "cms_user_karma",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    user_id = table.Column<int>(type: "int", nullable: false),
                    sender_id = table.Column<int>(type: "int", nullable: false),
                    points = table.Column<short>(type: "smallint", nullable: false),
                    senddate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cms_user_karma", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_unicode_ci");

            migrationBuilder.CreateTable(
                name: "cms_user_msg",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    to_id = table.Column<int>(type: "int", nullable: false),
                    from_id = table.Column<int>(type: "int", nullable: false),
                    senddate = table.Column<DateTime>(type: "datetime", nullable: false),
                    is_new = table.Column<bool>(type: "tinyint(1)", nullable: false, defaultValueSql: "'1'"),
                    message = table.Column<string>(type: "text", nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    to_del = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    from_del = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cms_user_msg", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_unicode_ci");

            migrationBuilder.CreateTable(
                name: "cms_user_photos",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    user_id = table.Column<int>(type: "int", nullable: false),
                    album_id = table.Column<int>(type: "int", nullable: false),
                    pubdate = table.Column<DateTime>(type: "datetime", nullable: false),
                    title = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    description = table.Column<string>(type: "text", nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    allow_who = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: false, defaultValueSql: "'all'", collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    hits = table.Column<int>(type: "int", nullable: false),
                    imageurl = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cms_user_photos", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_unicode_ci");

            migrationBuilder.CreateTable(
                name: "cms_user_profiles",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    user_id = table.Column<int>(type: "int", nullable: false),
                    city = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    description = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    showmail = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    showbirth = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    showicq = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    karma = table.Column<int>(type: "int", nullable: false),
                    imageurl = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    allow_who = table.Column<string>(type: "varchar(35)", maxLength: 35, nullable: false, defaultValueSql: "'all'", collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    signature = table.Column<string>(type: "varchar(240)", maxLength: 240, nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    signature_html = table.Column<string>(type: "varchar(300)", maxLength: 300, nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    gender = table.Column<string>(type: "varchar(1)", maxLength: 1, nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    formsdata = table.Column<string>(type: "varchar(800)", maxLength: 800, nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    email_newmsg = table.Column<int>(type: "int", nullable: false, defaultValueSql: "'1'"),
                    cm_subscribe = table.Column<string>(type: "varchar(4)", maxLength: 4, nullable: false, defaultValueSql: "'both'", collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    stats = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cms_user_profiles", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_unicode_ci");

            migrationBuilder.CreateTable(
                name: "cms_user_wall",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    user_id = table.Column<int>(type: "int", nullable: false),
                    author_id = table.Column<int>(type: "int", nullable: false),
                    pubdate = table.Column<DateTime>(type: "datetime", nullable: false),
                    content = table.Column<string>(type: "text", nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    usertype = table.Column<string>(type: "varchar(8)", maxLength: 8, nullable: false, defaultValueSql: "'users'", collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cms_user_wall", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_unicode_ci");

            migrationBuilder.CreateTable(
                name: "cms_users_activate",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    pubdate = table.Column<DateTime>(type: "datetime", nullable: false),
                    user_id = table.Column<int>(type: "int", nullable: false),
                    code = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cms_users_activate", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_unicode_ci");

            migrationBuilder.CreateTable(
                name: "app_roleclaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "longtext", nullable: true, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ClaimValue = table.Column<string>(type: "longtext", nullable: true, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_app_roleclaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_app_roleclaims_app_roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "app_roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "таблица для app_roleclaims")
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_unicode_ci");

            migrationBuilder.CreateTable(
                name: "app_userclaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "longtext", nullable: true, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ClaimValue = table.Column<string>(type: "longtext", nullable: true, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_app_userclaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_app_userclaims_app_users_UserId",
                        column: x => x.UserId,
                        principalTable: "app_users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "таблица для app_userclaims")
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_unicode_ci");

            migrationBuilder.CreateTable(
                name: "app_userlogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "varchar(255)", nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ProviderKey = table.Column<string>(type: "varchar(255)", nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ProviderDisplayName = table.Column<string>(type: "longtext", nullable: true, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_app_userlogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_app_userlogins_app_users_UserId",
                        column: x => x.UserId,
                        principalTable: "app_users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "таблица для app_userlogins")
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_unicode_ci");

            migrationBuilder.CreateTable(
                name: "app_userroles",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_app_userroles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_app_userroles_app_roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "app_roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_app_userroles_app_users_UserId",
                        column: x => x.UserId,
                        principalTable: "app_users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "таблица для app_userroles")
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_unicode_ci");

            migrationBuilder.CreateTable(
                name: "app_usertokens",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    LoginProvider = table.Column<string>(type: "varchar(255)", nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name = table.Column<string>(type: "varchar(255)", nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Value = table.Column<string>(type: "longtext", nullable: true, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_app_usertokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_app_usertokens_app_users_UserId",
                        column: x => x.UserId,
                        principalTable: "app_users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "таблица для app_usertokens")
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_unicode_ci");

            migrationBuilder.CreateTable(
                name: "cms_users",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    group_id = table.Column<int>(type: "int", nullable: false, defaultValueSql: "'1'"),
                    login = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    nickname = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    password = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    email = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    icq = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    regdate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "'1000-01-01 00:00:00'"),
                    logdate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "'1000-01-01 00:00:00'"),
                    birthdate = table.Column<DateTime>(type: "date", nullable: false, defaultValueSql: "'1000-01-01'"),
                    is_locked = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    is_deleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    is_logged_once = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    rating = table.Column<int>(type: "int", nullable: false),
                    points = table.Column<int>(type: "int", nullable: false),
                    last_ip = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    status = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    status_date = table.Column<DateTime>(type: "datetime", nullable: false),
                    invited_by = table.Column<int>(type: "int", nullable: true),
                    invdate = table.Column<DateTime>(type: "datetime", nullable: true),
                    openid = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: true, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AppUserId = table.Column<int>(type: "int", nullable: false),
                    Surname = table.Column<string>(type: "longtext", nullable: true, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name = table.Column<string>(type: "longtext", nullable: true, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Fathername = table.Column<string>(type: "longtext", nullable: true, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Mobile = table.Column<string>(type: "longtext", nullable: true, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cms_users", x => x.id);
                    table.ForeignKey(
                        name: "FK_cms_users_app_users_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "app_users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_unicode_ci");

            migrationBuilder.CreateIndex(
                name: "IX_app_roleclaims_RoleId",
                table: "app_roleclaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "app_roles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_app_userclaims_UserId",
                table: "app_userclaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_app_userlogins_UserId",
                table: "app_userlogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_app_userroles_RoleId",
                table: "app_userroles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "app_users",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "app_users",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "name",
                table: "cms_actions",
                columns: new[] { "name", "is_visible" });

            migrationBuilder.CreateIndex(
                name: "action_id",
                table: "cms_actions_log",
                columns: new[] { "action_id", "user_id" });

            migrationBuilder.CreateIndex(
                name: "object_id",
                table: "cms_actions_log",
                column: "object_id");

            migrationBuilder.CreateIndex(
                name: "target_id",
                table: "cms_actions_log",
                column: "target_id");

            migrationBuilder.CreateIndex(
                name: "ip",
                table: "cms_banlist",
                column: "ip");

            migrationBuilder.CreateIndex(
                name: "user_id",
                table: "cms_banlist",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "banner_id",
                table: "cms_banner_hits",
                column: "banner_id");

            migrationBuilder.CreateIndex(
                name: "ip1",
                table: "cms_banner_hits",
                columns: new[] { "ip", "banner_id" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "blog_id",
                table: "cms_blog_authors",
                column: "blog_id");

            migrationBuilder.CreateIndex(
                name: "user_id2",
                table: "cms_blog_authors",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "blog_id1",
                table: "cms_blog_cats",
                column: "blog_id");

            migrationBuilder.CreateIndex(
                name: "blog_id2",
                table: "cms_blog_posts",
                column: "blog_id");

            migrationBuilder.CreateIndex(
                name: "content_html",
                table: "cms_blog_posts",
                column: "content_html")
                .Annotation("MySql:FullTextIndex", true);

            migrationBuilder.CreateIndex(
                name: "seolink1",
                table: "cms_blog_posts",
                column: "seolink");

            migrationBuilder.CreateIndex(
                name: "title",
                table: "cms_blog_posts",
                column: "title")
                .Annotation("MySql:FullTextIndex", true);

            migrationBuilder.CreateIndex(
                name: "user_id3",
                table: "cms_blog_posts",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "pubdate",
                table: "cms_blogs",
                column: "pubdate");

            migrationBuilder.CreateIndex(
                name: "seolink",
                table: "cms_blogs",
                column: "seolink");

            migrationBuilder.CreateIndex(
                name: "user_id1",
                table: "cms_blogs",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "NSLeft",
                table: "cms_board_cats",
                columns: new[] { "NSLeft", "NSRight" });

            migrationBuilder.CreateIndex(
                name: "parent_id",
                table: "cms_board_cats",
                column: "parent_id");

            migrationBuilder.CreateIndex(
                name: "category_id",
                table: "cms_board_items",
                column: "category_id");

            migrationBuilder.CreateIndex(
                name: "city",
                table: "cms_board_items",
                column: "city");

            migrationBuilder.CreateIndex(
                name: "content",
                table: "cms_board_items",
                column: "content")
                .Annotation("MySql:FullTextIndex", true);

            migrationBuilder.CreateIndex(
                name: "ip2",
                table: "cms_board_items",
                column: "ip");

            migrationBuilder.CreateIndex(
                name: "obtype",
                table: "cms_board_items",
                column: "obtype");

            migrationBuilder.CreateIndex(
                name: "title1",
                table: "cms_board_items",
                column: "title")
                .Annotation("MySql:FullTextIndex", true);

            migrationBuilder.CreateIndex(
                name: "user_id4",
                table: "cms_board_items",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "NSLeft1",
                table: "cms_category",
                columns: new[] { "NSLeft", "NSRight" });

            migrationBuilder.CreateIndex(
                name: "parent_id1",
                table: "cms_category",
                column: "parent_id");

            migrationBuilder.CreateIndex(
                name: "seolink2",
                table: "cms_category",
                column: "seolink");

            migrationBuilder.CreateIndex(
                name: "admin_id",
                table: "cms_clubs",
                column: "admin_id");

            migrationBuilder.CreateIndex(
                name: "pubdate1",
                table: "cms_clubs",
                column: "pubdate");

            migrationBuilder.CreateIndex(
                name: "target",
                table: "cms_comment_targets",
                column: "target",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "target_id1",
                table: "cms_comments",
                column: "target_id");

            migrationBuilder.CreateIndex(
                name: "user_id5",
                table: "cms_comments",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "category_id1",
                table: "cms_content",
                column: "category_id");

            migrationBuilder.CreateIndex(
                name: "content1",
                table: "cms_content",
                column: "content")
                .Annotation("MySql:FullTextIndex", true);

            migrationBuilder.CreateIndex(
                name: "seolink3",
                table: "cms_content",
                column: "seolink");

            migrationBuilder.CreateIndex(
                name: "title2",
                table: "cms_content",
                column: "title")
                .Annotation("MySql:FullTextIndex", true);

            migrationBuilder.CreateIndex(
                name: "user_id6",
                table: "cms_content",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "content_id",
                table: "cms_content_access",
                column: "content_id");

            migrationBuilder.CreateIndex(
                name: "job_name",
                table: "cms_cron_jobs",
                columns: new[] { "job_name", "is_enabled" });

            migrationBuilder.CreateIndex(
                name: "event",
                table: "cms_event_hooks",
                columns: new[] { "event", "plugin_id" });

            migrationBuilder.CreateIndex(
                name: "category_id2",
                table: "cms_faq_quests",
                column: "category_id");

            migrationBuilder.CreateIndex(
                name: "quest",
                table: "cms_faq_quests",
                columns: new[] { "quest", "answer" })
                .Annotation("MySql:FullTextIndex", true);

            migrationBuilder.CreateIndex(
                name: "form_id",
                table: "cms_form_fields",
                column: "form_id");

            migrationBuilder.CreateIndex(
                name: "title3",
                table: "cms_forms",
                column: "title");

            migrationBuilder.CreateIndex(
                name: "seolink4",
                table: "cms_forum_cats",
                column: "seolink");

            migrationBuilder.CreateIndex(
                name: "post_id",
                table: "cms_forum_files",
                column: "post_id");

            migrationBuilder.CreateIndex(
                name: "thread_id",
                table: "cms_forum_polls",
                column: "thread_id");

            migrationBuilder.CreateIndex(
                name: "content_html1",
                table: "cms_forum_posts",
                column: "content_html")
                .Annotation("MySql:FullTextIndex", true);

            migrationBuilder.CreateIndex(
                name: "thread_id1",
                table: "cms_forum_posts",
                columns: new[] { "thread_id", "pubdate" });

            migrationBuilder.CreateIndex(
                name: "user_id7",
                table: "cms_forum_posts",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "forum_id",
                table: "cms_forum_threads",
                column: "forum_id");

            migrationBuilder.CreateIndex(
                name: "rel_id",
                table: "cms_forum_threads",
                column: "rel_id");

            migrationBuilder.CreateIndex(
                name: "title4",
                table: "cms_forum_threads",
                column: "title")
                .Annotation("MySql:FullTextIndex", true);

            migrationBuilder.CreateIndex(
                name: "user_id8",
                table: "cms_forum_threads",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "poll_id",
                table: "cms_forum_votes",
                column: "poll_id");

            migrationBuilder.CreateIndex(
                name: "user_id9",
                table: "cms_forum_votes",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "category_id3",
                table: "cms_forums",
                column: "category_id");

            migrationBuilder.CreateIndex(
                name: "NSLeft2",
                table: "cms_forums",
                columns: new[] { "NSLeft", "NSRight" });

            migrationBuilder.CreateIndex(
                name: "parent_id2",
                table: "cms_forums",
                column: "parent_id");

            migrationBuilder.CreateIndex(
                name: "country_id",
                table: "cms_geo_cities",
                column: "country_id");

            migrationBuilder.CreateIndex(
                name: "name1",
                table: "cms_geo_cities",
                column: "name");

            migrationBuilder.CreateIndex(
                name: "region_id",
                table: "cms_geo_cities",
                column: "region_id");

            migrationBuilder.CreateIndex(
                name: "alpha2",
                table: "cms_geo_countries",
                column: "alpha2");

            migrationBuilder.CreateIndex(
                name: "alpha3",
                table: "cms_geo_countries",
                column: "alpha3");

            migrationBuilder.CreateIndex(
                name: "iso",
                table: "cms_geo_countries",
                column: "iso");

            migrationBuilder.CreateIndex(
                name: "name2",
                table: "cms_geo_countries",
                column: "name");

            migrationBuilder.CreateIndex(
                name: "ordering",
                table: "cms_geo_countries",
                column: "ordering");

            migrationBuilder.CreateIndex(
                name: "country_id1",
                table: "cms_geo_regions",
                column: "country_id");

            migrationBuilder.CreateIndex(
                name: "NSLeft3",
                table: "cms_menu",
                columns: new[] { "NSLeft", "NSRight" });

            migrationBuilder.CreateIndex(
                name: "parent_id3",
                table: "cms_menu",
                column: "parent_id");

            migrationBuilder.CreateIndex(
                name: "content2",
                table: "cms_modules",
                column: "content")
                .Annotation("MySql:FullTextIndex", true);

            migrationBuilder.CreateIndex(
                name: "position",
                table: "cms_modules",
                column: "position");

            migrationBuilder.CreateIndex(
                name: "menu_id",
                table: "cms_modules_bind",
                column: "menu_id");

            migrationBuilder.CreateIndex(
                name: "module_id",
                table: "cms_modules_bind",
                column: "module_id");

            migrationBuilder.CreateIndex(
                name: "position1",
                table: "cms_modules_bind",
                column: "position");

            migrationBuilder.CreateIndex(
                name: "sess_id",
                table: "cms_online",
                column: "sess_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "user_id10",
                table: "cms_online",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "NSLeft4",
                table: "cms_photo_albums",
                columns: new[] { "NSLeft", "NSRight" });

            migrationBuilder.CreateIndex(
                name: "parent_id4",
                table: "cms_photo_albums",
                column: "parent_id");

            migrationBuilder.CreateIndex(
                name: "user_id11",
                table: "cms_photo_albums",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "album_id",
                table: "cms_photo_files",
                column: "album_id");

            migrationBuilder.CreateIndex(
                name: "owner",
                table: "cms_photo_files",
                column: "owner");

            migrationBuilder.CreateIndex(
                name: "title5",
                table: "cms_photo_files",
                columns: new[] { "title", "description" })
                .Annotation("MySql:FullTextIndex", true);

            migrationBuilder.CreateIndex(
                name: "user_id12",
                table: "cms_photo_files",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "ip3",
                table: "cms_polls_log",
                column: "ip");

            migrationBuilder.CreateIndex(
                name: "poll_id1",
                table: "cms_polls_log",
                column: "poll_id");

            migrationBuilder.CreateIndex(
                name: "user_id13",
                table: "cms_polls_log",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "target1",
                table: "cms_rating_targets",
                column: "target",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "item_id",
                table: "cms_ratings",
                column: "item_id");

            migrationBuilder.CreateIndex(
                name: "user_id14",
                table: "cms_ratings",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "item_id1",
                table: "cms_ratings_total",
                column: "item_id");

            migrationBuilder.CreateIndex(
                name: "target2",
                table: "cms_ratings_total",
                columns: new[] { "target", "item_id" });

            migrationBuilder.CreateIndex(
                name: "date",
                table: "cms_search",
                column: "date");

            migrationBuilder.CreateIndex(
                name: "session_id",
                table: "cms_search",
                column: "session_id");

            migrationBuilder.CreateIndex(
                name: "target_id2",
                table: "cms_subscribe",
                column: "target_id");

            migrationBuilder.CreateIndex(
                name: "user_id15",
                table: "cms_subscribe",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "target4",
                table: "cms_tag_targets",
                column: "target",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "item_id2",
                table: "cms_tags",
                column: "item_id");

            migrationBuilder.CreateIndex(
                name: "tag",
                table: "cms_tags",
                column: "tag");

            migrationBuilder.CreateIndex(
                name: "target3",
                table: "cms_tags",
                columns: new[] { "target", "tag" });

            migrationBuilder.CreateIndex(
                name: "NSLeft5",
                table: "cms_uc_cats",
                columns: new[] { "NSLeft", "NSRight" });

            migrationBuilder.CreateIndex(
                name: "cat_id",
                table: "cms_uc_cats_access",
                columns: new[] { "cat_id", "group_id" });

            migrationBuilder.CreateIndex(
                name: "cat_id",
                table: "cms_uc_discount",
                column: "cat_id");

            migrationBuilder.CreateIndex(
                name: "category_id4",
                table: "cms_uc_items",
                column: "category_id");

            migrationBuilder.CreateIndex(
                name: "title6",
                table: "cms_uc_items",
                columns: new[] { "title", "fieldsdata" })
                .Annotation("MySql:FullTextIndex", true);

            migrationBuilder.CreateIndex(
                name: "session_id1",
                table: "cms_upload_images",
                column: "session_id");

            migrationBuilder.CreateIndex(
                name: "target_id3",
                table: "cms_upload_images",
                column: "target_id");

            migrationBuilder.CreateIndex(
                name: "allow_who",
                table: "cms_user_albums",
                column: "allow_who");

            migrationBuilder.CreateIndex(
                name: "user_id16",
                table: "cms_user_albums",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "user_id17",
                table: "cms_user_awards",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "club_id",
                table: "cms_user_clubs",
                column: "club_id");

            migrationBuilder.CreateIndex(
                name: "user_id18",
                table: "cms_user_clubs",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "user_id19",
                table: "cms_user_files",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "from_id",
                table: "cms_user_friends",
                column: "from_id");

            migrationBuilder.CreateIndex(
                name: "to_id",
                table: "cms_user_friends",
                column: "to_id");

            migrationBuilder.CreateIndex(
                name: "access_type",
                table: "cms_user_groups_access",
                column: "access_type",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "code",
                table: "cms_user_invites",
                columns: new[] { "code", "owner_id", "is_used" });

            migrationBuilder.CreateIndex(
                name: "user_id20",
                table: "cms_user_karma",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "from_del",
                table: "cms_user_msg",
                column: "from_del");

            migrationBuilder.CreateIndex(
                name: "from_id1",
                table: "cms_user_msg",
                column: "from_id");

            migrationBuilder.CreateIndex(
                name: "to_del",
                table: "cms_user_msg",
                column: "to_del");

            migrationBuilder.CreateIndex(
                name: "to_id1",
                table: "cms_user_msg",
                column: "to_id");

            migrationBuilder.CreateIndex(
                name: "album_id1",
                table: "cms_user_photos",
                column: "album_id");

            migrationBuilder.CreateIndex(
                name: "user_id21",
                table: "cms_user_photos",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "city1",
                table: "cms_user_profiles",
                column: "city");

            migrationBuilder.CreateIndex(
                name: "description",
                table: "cms_user_profiles",
                column: "description")
                .Annotation("MySql:IndexPrefixLength", new[] { 333 });

            migrationBuilder.CreateIndex(
                name: "formsdata",
                table: "cms_user_profiles",
                column: "formsdata")
                .Annotation("MySql:IndexPrefixLength", new[] { 333 });

            migrationBuilder.CreateIndex(
                name: "gender",
                table: "cms_user_profiles",
                column: "gender");

            migrationBuilder.CreateIndex(
                name: "user_id22",
                table: "cms_user_profiles",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "author_id",
                table: "cms_user_wall",
                column: "author_id");

            migrationBuilder.CreateIndex(
                name: "user_id23",
                table: "cms_user_wall",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "birthdate",
                table: "cms_users",
                column: "birthdate");

            migrationBuilder.CreateIndex(
                name: "email",
                table: "cms_users",
                column: "email");

            migrationBuilder.CreateIndex(
                name: "group_id",
                table: "cms_users",
                column: "group_id");

            migrationBuilder.CreateIndex(
                name: "invited_by",
                table: "cms_users",
                column: "invited_by");

            migrationBuilder.CreateIndex(
                name: "IX_cms_users_AppUserId",
                table: "cms_users",
                column: "AppUserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "login",
                table: "cms_users",
                column: "login");

            migrationBuilder.CreateIndex(
                name: "openid",
                table: "cms_users",
                column: "openid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "app_roleclaims");

            migrationBuilder.DropTable(
                name: "app_userclaims");

            migrationBuilder.DropTable(
                name: "app_userlogins");

            migrationBuilder.DropTable(
                name: "app_userroles");

            migrationBuilder.DropTable(
                name: "app_usertokens");

            migrationBuilder.DropTable(
                name: "cms_actions");

            migrationBuilder.DropTable(
                name: "cms_actions_log");

            migrationBuilder.DropTable(
                name: "cms_banlist");

            migrationBuilder.DropTable(
                name: "cms_banner_hits");

            migrationBuilder.DropTable(
                name: "cms_banners");

            migrationBuilder.DropTable(
                name: "cms_blog_authors");

            migrationBuilder.DropTable(
                name: "cms_blog_cats");

            migrationBuilder.DropTable(
                name: "cms_blog_posts");

            migrationBuilder.DropTable(
                name: "cms_blogs");

            migrationBuilder.DropTable(
                name: "cms_board_cats");

            migrationBuilder.DropTable(
                name: "cms_board_items");

            migrationBuilder.DropTable(
                name: "cms_cache");

            migrationBuilder.DropTable(
                name: "cms_category");

            migrationBuilder.DropTable(
                name: "cms_clubs");

            migrationBuilder.DropTable(
                name: "cms_comment_targets");

            migrationBuilder.DropTable(
                name: "cms_comments");

            migrationBuilder.DropTable(
                name: "cms_components");

            migrationBuilder.DropTable(
                name: "cms_content");

            migrationBuilder.DropTable(
                name: "cms_content_access");

            migrationBuilder.DropTable(
                name: "cms_cron_jobs");

            migrationBuilder.DropTable(
                name: "cms_downloads");

            migrationBuilder.DropTable(
                name: "cms_event_hooks");

            migrationBuilder.DropTable(
                name: "cms_faq_cats");

            migrationBuilder.DropTable(
                name: "cms_faq_quests");

            migrationBuilder.DropTable(
                name: "cms_filters");

            migrationBuilder.DropTable(
                name: "cms_form_fields");

            migrationBuilder.DropTable(
                name: "cms_forms");

            migrationBuilder.DropTable(
                name: "cms_forum_cats");

            migrationBuilder.DropTable(
                name: "cms_forum_files");

            migrationBuilder.DropTable(
                name: "cms_forum_polls");

            migrationBuilder.DropTable(
                name: "cms_forum_posts");

            migrationBuilder.DropTable(
                name: "cms_forum_threads");

            migrationBuilder.DropTable(
                name: "cms_forum_votes");

            migrationBuilder.DropTable(
                name: "cms_forums");

            migrationBuilder.DropTable(
                name: "cms_geo_cities");

            migrationBuilder.DropTable(
                name: "cms_geo_countries");

            migrationBuilder.DropTable(
                name: "cms_geo_regions");

            migrationBuilder.DropTable(
                name: "cms_menu");

            migrationBuilder.DropTable(
                name: "cms_modules");

            migrationBuilder.DropTable(
                name: "cms_modules_bind");

            migrationBuilder.DropTable(
                name: "cms_ns_transactions");

            migrationBuilder.DropTable(
                name: "cms_online");

            migrationBuilder.DropTable(
                name: "cms_photo_albums");

            migrationBuilder.DropTable(
                name: "cms_photo_files");

            migrationBuilder.DropTable(
                name: "cms_plugins");

            migrationBuilder.DropTable(
                name: "cms_polls");

            migrationBuilder.DropTable(
                name: "cms_polls_log");

            migrationBuilder.DropTable(
                name: "cms_rating_targets");

            migrationBuilder.DropTable(
                name: "cms_ratings");

            migrationBuilder.DropTable(
                name: "cms_ratings_total");

            migrationBuilder.DropTable(
                name: "cms_search");

            migrationBuilder.DropTable(
                name: "cms_subscribe");

            migrationBuilder.DropTable(
                name: "cms_tag_targets");

            migrationBuilder.DropTable(
                name: "cms_tags");

            migrationBuilder.DropTable(
                name: "cms_uc_cart");

            migrationBuilder.DropTable(
                name: "cms_uc_cats");

            migrationBuilder.DropTable(
                name: "cms_uc_cats_access");

            migrationBuilder.DropTable(
                name: "cms_uc_discount");

            migrationBuilder.DropTable(
                name: "cms_uc_items");

            migrationBuilder.DropTable(
                name: "cms_uc_ratings");

            migrationBuilder.DropTable(
                name: "cms_uc_tags");

            migrationBuilder.DropTable(
                name: "cms_upload_images");

            migrationBuilder.DropTable(
                name: "cms_user_albums");

            migrationBuilder.DropTable(
                name: "cms_user_autoawards");

            migrationBuilder.DropTable(
                name: "cms_user_awards");

            migrationBuilder.DropTable(
                name: "cms_user_clubs");

            migrationBuilder.DropTable(
                name: "cms_user_files");

            migrationBuilder.DropTable(
                name: "cms_user_friends");

            migrationBuilder.DropTable(
                name: "cms_user_groups");

            migrationBuilder.DropTable(
                name: "cms_user_groups_access");

            migrationBuilder.DropTable(
                name: "cms_user_invites");

            migrationBuilder.DropTable(
                name: "cms_user_karma");

            migrationBuilder.DropTable(
                name: "cms_user_msg");

            migrationBuilder.DropTable(
                name: "cms_user_photos");

            migrationBuilder.DropTable(
                name: "cms_user_profiles");

            migrationBuilder.DropTable(
                name: "cms_user_wall");

            migrationBuilder.DropTable(
                name: "cms_users");

            migrationBuilder.DropTable(
                name: "cms_users_activate");

            migrationBuilder.DropTable(
                name: "app_roles");

            migrationBuilder.DropTable(
                name: "app_users");
        }
    }
}
