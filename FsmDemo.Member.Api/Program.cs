using FsmDemo.Member.Core;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddScoped<MemberRepo>();
builder.Services.AddScoped<MemberStateMachine>();
builder.Services.AddScoped<MemberService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");

    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseMiddleware<MemberServiceMiddle>();

app.UseAuthorization();

app.MapControllerRoute("default",
    "{controller=Member}/{action=Index}/{id?}");

app.Run();