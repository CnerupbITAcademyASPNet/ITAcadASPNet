namespace WebApplication1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // ������ ������ builder � ��� ������� ��������� ����������.
            // �� ����������� ���-���������� � �������� ��� �����������.
            var builder = WebApplication.CreateBuilder(args);

            // ��������� ������� � ��������� ������������.
            // � ������ ������ �� ���������� ����������� � ������������� (Views) � ��� ������ MVC.
            builder.Services.AddControllersWithViews();

            // ������ ������� ���-���������� �� ������ �������� builder'�.
            var app = builder.Build();

            // ����������� middleware (������������� ����������� ��������).
            // ���� �� �� � ������ ���������� (��������, �� �����), ��:
            if (!app.Environment.IsDevelopment())
            {
                // ���������� �������� � �������, ���� ���������� ���������� (������ �����).
                app.UseExceptionHandler("/Home/Error");

                // HSTS � HTTP Strict Transport Security.
                // ������� ��������, ��� ����� ������������ HTTPS.
                // ������ �������� � ����������.
                app.UseHsts(); // �� ��������� 30 ����
            }

            // �������������� ��� HTTP-������� �� HTTPS (��� ������������).
            app.UseHttpsRedirection();

            // ���������� ������������� � ��� �������, ������� ����������,
            // ����� ���������� � ����� (action) ������� ��� ��������� �� URL.
            app.UseRouting();

            // ���������� ����������� (�� �������������� �� ���������, ��� ��� ���� ������ �� ������).
            app.UseAuthorization();

            // ���������� ����������� ����������� ������ (��������, CSS, JS, �����������).
            app.MapStaticAssets(); // ��������, ��� ��������� ����� ��� �� ������

            // ����������� ������� �� ���������:
            // ��������, ��� ��������� � / ����� ������ ���������� Home � ����� Index.
            // {id?} � ��������, ��� �������� id ��������������.
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}")
                .WithStaticAssets(); // ��������� ����������� ������

            // ��������� ����������. ��� ���� ������ ������ �� ����� ��������.
            app.Run();
        }
    }
}
