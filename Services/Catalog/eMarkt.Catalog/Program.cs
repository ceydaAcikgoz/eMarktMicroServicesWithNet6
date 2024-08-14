using eMarkt.Catalog.Services.CategoryServices;
using eMarkt.Catalog.Services.ProductDetailServices;
using eMarkt.Catalog.Services.ProductImageServices;
using eMarkt.Catalog.Services.ProductServices;
using eMarkt.Catalog.Settings;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System.Reflection;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.



//Dependency Injection: Dependency Injection (Ba��ml�l�k Enjeksiyonu), bir bile�enin ihtiya� duydu�u di�er bile�enleri d��ar�dan almas� ve enjekte edilmesi prensibidir. Bu prensip, bir bile�enin kendi ba��ml�l�klar�n� olu�turmak yerine d��ar�dan almas�n� sa�lar, bu da kodun daha esnek ve test edilebilir olmas�n� sa�lar. �rne�in, bir �r�n kontrolc�s�, �r�n servisi gibi ba��ml�l�klar� d��ar�dan al�r ve IoC Container taraf�ndan enjekte edilir.

//Singleton: Yaln�zca bir �rne�in olu�turulup uygulama boyunca payla��lmas�n� sa�lar. Her istemciye ayn� �rne�i verir.
//Scoped: Her bir HTTP iste�i i�in ayn� �rne�in kullan�lmas�n� sa�lar. Yani, ayn� istek kapsam�nda ayn� �rne�i payla��r.
//Transient: Her bir istek i�in yeni bir �rne�in olu�turulmas�n� sa�lar. Yani, her bir istek i�in ayr� bir �rnek sa�lar.


//Uygulamada method �a��r�ld���nda nesnesini olu�turacak.
builder.Services.AddScoped<ICategoryService, CategoryService>(); 
builder.Services.AddScoped<IProductService, ProductService>(); 
builder.Services.AddScoped<IProductDetailService, ProductDetailService>(); 
builder.Services.AddScoped<IProductImageService, ProductImageService>();


builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

builder.Services.Configure<DatabaseSettings>(builder.Configuration.GetSection("DatabaseSettings"));
builder.Services.AddScoped<IDatabaseSettings, DatabaseSettings>(sp =>
{
    return sp.GetRequiredService<IOptions<DatabaseSettings>>().Value;
});



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
