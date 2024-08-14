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



//Dependency Injection: Dependency Injection (Baðýmlýlýk Enjeksiyonu), bir bileþenin ihtiyaç duyduðu diðer bileþenleri dýþarýdan almasý ve enjekte edilmesi prensibidir. Bu prensip, bir bileþenin kendi baðýmlýlýklarýný oluþturmak yerine dýþarýdan almasýný saðlar, bu da kodun daha esnek ve test edilebilir olmasýný saðlar. Örneðin, bir ürün kontrolcüsü, ürün servisi gibi baðýmlýlýklarý dýþarýdan alýr ve IoC Container tarafýndan enjekte edilir.

//Singleton: Yalnýzca bir örneðin oluþturulup uygulama boyunca paylaþýlmasýný saðlar. Her istemciye ayný örneði verir.
//Scoped: Her bir HTTP isteði için ayný örneðin kullanýlmasýný saðlar. Yani, ayný istek kapsamýnda ayný örneði paylaþýr.
//Transient: Her bir istek için yeni bir örneðin oluþturulmasýný saðlar. Yani, her bir istek için ayrý bir örnek saðlar.


//Uygulamada method çaðýrýldýðýnda nesnesini oluþturacak.
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
