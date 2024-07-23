using BookStore.Context;
using BookStore.Services.AdminService;
using BookStore.Services.AuthorService;
using BookStore.Services.BasketItemService;
using BookStore.Services.BasketTotalService;
using BookStore.Services.BookService;
using BookStore.Services.CashBoxService;
using BookStore.Services.CategoryService;
using BookStore.Services.EmployeeService;
using BookStore.Services.SellingService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddTransient<DapperContext>();
builder.Services.AddTransient<IAdminService,AdminService>();
builder.Services.AddTransient<IAuthorService, AuthorService>();
builder.Services.AddTransient<IBookService, BookService>();
//builder.Services.AddTransient<IBasketItemService, BasketItemService>();
//builder.Services.AddTransient<IBasketTotalService, BasketTotalService>();
builder.Services.AddTransient<ICashBoxService, CashBoxService>();
builder.Services.AddTransient<IEmployeeService, EmployeeService>();
builder.Services.AddTransient<ICategoryService, CategoryService>();
builder.Services.AddTransient<ISellingService, SellingService>();

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

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
