namespace WebApplication1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Создаём объект builder — это главный строитель приложения.
            // Он настраивает веб-приложение и собирает все зависимости.
            var builder = WebApplication.CreateBuilder(args);

            // Добавляем сервисы в контейнер зависимостей.
            // В данном случае мы подключаем контроллеры и представления (Views) — это основа MVC.
            builder.Services.AddControllersWithViews();

            // Создаём готовое веб-приложение на основе настроек builder'а.
            var app = builder.Build();

            // Настраиваем middleware (промежуточные обработчики запросов).
            // Если мы НЕ в режиме разработки (например, на проде), то:
            if (!app.Environment.IsDevelopment())
            {
                // Показываем страницу с ошибкой, если происходит исключение (вместо дампа).
                app.UseExceptionHandler("/Home/Error");

                // HSTS — HTTP Strict Transport Security.
                // Говорит браузеру, что нужно использовать HTTPS.
                // Обычно включают в продакшене.
                app.UseHsts(); // по умолчанию 30 дней
            }

            // Перенаправляем все HTTP-запросы на HTTPS (для безопасности).
            app.UseHttpsRedirection();

            // Подключаем маршрутизацию — это система, которая определяет,
            // какой контроллер и метод (action) вызвать при обращении по URL.
            app.UseRouting();

            // Подключаем авторизацию (но аутентификация не настроена, так что пока ничего не делает).
            app.UseAuthorization();

            // Подключаем отображение статических файлов (например, CSS, JS, изображения).
            app.MapStaticAssets(); // возможно, это кастомный метод или из пакета

            // Настраиваем маршрут по умолчанию:
            // Например, при обращении к / будет вызван контроллер Home и метод Index.
            // {id?} — означает, что параметр id необязательный.
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}")
                .WithStaticAssets(); // поддержка статических файлов

            // Запускаем приложение. Без этой строки ничего не будет работать.
            app.Run();
        }
    }
}
