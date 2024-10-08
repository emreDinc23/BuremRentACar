using RentacarApplication.Features.CQRS.Handlers.AboutHandlers;
using RentacarApplication.Features.CQRS.Handlers.BannerHandlers;
using RentacarApplication.Features.CQRS.Handlers.BrandHandlers;
using RentacarApplication.Features.CQRS.Handlers.CarHandlers;
using RentacarApplication.Features.CQRS.Handlers.CategoryHandlers;
using RentacarApplication.Features.CQRS.Handlers.ContactHandlers;
using RentacarApplication.Features.RepositoryPattern;
using RentacarApplication.Interfaces;
using RentacarApplication.Interfaces.BlogCommentsRepository;
using RentacarApplication.Interfaces.BlogInterfaces;
using RentacarApplication.Interfaces.CarInterfaces;
using RentacarApplication.Interfaces.TagCloudInterfaces;
using RentacarApplication.Services;
using RentacarPersistence.Context;
using RentacarPersistence.Repositories;
using RentacarPersistence.Repositories.BlogCommentsRepositories;
using RentacarPersistence.Repositories.BlogRepositories;
using RentacarPersistence.Repositories.CarPricingRepositories;
using RentacarPersistence.Repositories.CarRepositories;
using RentacarPersistence.Repositories.CommentRepositories;
using RentacarPersistence.Repositories.TagCloudRepositories;
using Rentacarproject.RentacarApplication.Interfaces.CarPricingInterfaces;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<RentacarContext>();
builder.Services.AddScoped<GetAboutQueryHandler>();
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped(typeof(ICarRepository), typeof(CarRepository));
builder.Services.AddScoped(typeof(IBlogRepository), typeof(BlogRepository));
builder.Services.AddScoped(typeof(ICarPricingRepository), typeof(CarPricingRepository));
builder.Services.AddScoped(typeof(ITagCloudRepository), typeof(TagCloudRepository));
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(CommentRepository<>));
builder.Services.AddScoped(typeof(IBlogCommentRepository), typeof(BlogCommentRepository));



builder.Services.AddScoped<GetAboutByIdQueryHandler>();
builder.Services.AddScoped<CreateAboutCommandHandler>();
builder.Services.AddScoped<UpdateAboutCommandHandler>();
builder.Services.AddScoped<RemoveAboutCommandHandler>();

builder.Services.AddScoped<CreateBannerCommandHandler>();
builder.Services.AddScoped<UpdateBannerCommandHandler>();
builder.Services.AddScoped<RemoverBannerCommandHandler>();
builder.Services.AddScoped<GetBannerQueryHandler>();
builder.Services.AddScoped<GetBannerByIdQueryHandler>();

builder.Services.AddScoped<GetBrandQueryHandler>();
builder.Services.AddScoped<GetBrandByIdQueryHandler>();
builder.Services.AddScoped<CreateBrandCommandHandler>();
builder.Services.AddScoped<UpdateBrandCommandHandler>();
builder.Services.AddScoped<RemoveBrandCommandHandler>();


builder.Services.AddScoped<GetCarQueryHandler>();
builder.Services.AddScoped<GetCarByIdQueryHandler>();
builder.Services.AddScoped<CreateCarCommandHandler>();
builder.Services.AddScoped<UpdateCarCommandHandler>();
builder.Services.AddScoped<RemoveCarCommandHandler>();
builder.Services.AddScoped<GetCarWithBrandQueryHandler>();
builder.Services.AddScoped<GetLast5CarWithBrandQueryHandler>();




builder.Services.AddScoped<GetCategoryQueryHandler>();
builder.Services.AddScoped<GetCategoryByIdQueryHandler>();
builder.Services.AddScoped<CreateCategoryCommandHandler>();
builder.Services.AddScoped<UpdateCategoryCommandHandler>();
builder.Services.AddScoped<RemoveCategoryCommandHandler>();

builder.Services.AddScoped<GetContactQueryHandler>();
builder.Services.AddScoped<GetContactByIdQueryHandler>();
builder.Services.AddScoped<CreateContactCommandHandler>();
builder.Services.AddScoped<UpdateContactCommandHandler>();
builder.Services.AddScoped<RemoveContactCommandHandler>();

builder.Services.AddApplicationService(builder.Configuration);

// Add services to the container.


builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();


app.Run();