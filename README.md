# مقدمه:

این فریمورک ترکیبی از دو فریمورک قدرتمند ایرانی [DTAT-Framework](https://github.com/DTAT-Framework "DTAT-Framework") و [Zamin](https://github.com/oroumand/Zamin "Zamin") میباشد. و گاها نام کدها تغییر داده شده.

همینجا جا دارد از اساتید عزیزم آقایان داریوش تصدیقی و علیرضا ارومند تشکر و قدردانی فراوان کنم. ❤




# ویژگی ها:

پیاده سازی شده با معماری پیاز  و مناسب برای DDD.

پیاده سازی CQRS با استافده از کتابخانه MediatR.

پیاده سازی ارتباطات بین سرویس ها (Domain Events) با استفاده از کتابخانه Masstransit.

برگشت دادن پیغام خطا بجای پرتاب استثنا با استفاده از کتابخانه FluentResults.

برای تزریق وابستگی از کتابخانه Scrutor استفاده شده است.

# نکات قابل توجه:

از آنجایی که نام ها به صورت کامل آورده شده و اختصار نویسی نشده است لازم "پشتیبانی از مسیرهای طولانی در ویندوز" LongPathsEnabled  را فعال کنید.

همیشه از بروز بودن NuGet پکیج ها اطنیتان حاصل کنید.

برای استفاده از مثال باید Rabbitmq را نصب داشته باشید.

برای استفاده از مثال باید MSSQL Server را نصب داشته باشید.

قبل از استفاده رشته اتصال دیتابیس را در فایل appsettings.json در پروژه Endpoint Api را تنظیم کرده و Update-Database را اجرا کنید.

این نمونه مثال فقط برای نمایش چگونگی کار کردن با فریمورک است و تفکر زیاد روی درست بودن منطق کسب و کار نشده است. 

در بعض مواقع برای کار های یکسان ، فایل ها یا روش های متفاوتی انجام شده است مانند استفاده از کلاس guard یا انجام همان کار به صورت دستی. ویا در بحث Domain Event ها استفاده از کلاس و در جای دیگر رکورد و یا انترفیس، که برای درک این کار باید مستندات کتابخانه [MassTransit](https://masstransit.io/documentation/concepts/messages#message-types "MassTransit") مراجع فرمایید. دلیل اینکار فقط نمایش انجام یک کار با روش های متفاوت است.

در این زمان هنوز AAA (Authentication, Authorization, Accounting) پیاده سازی نشده است و این کار باید به صورت دستی انجام شود.

اطلاع از نحوه کارکرد کتابخانه های استفاده شده در این فریمورک خالی از لطف نیست.

# دانلود فریمورک برای ویژوال استودیو 2022:

یا از طریف[ ویژوال استودیو مارکتپلیس](https://marketplace.visualstudio.com/items?itemName=MicroDomainFlow.armanespiar " ویژوال استودیو مارکتپلیس") آن را دانلود کنید. و یا از طریق منوی Extensions -> Manage Extensions رفته و نام MDFTemplate را جستوجو کرده و آن را نصب کنید و به همین ترتیب میتوانید آن را حذف نمایید.


# ابزارهای مفید

### آیتم ها (MDFItems): برای ساخت سریع کلاس های Entity و ValueObject برای دانلود و اطلاعات بیشتر [این مخزن](https://github.com/MicroDomainFlow/MDFItems "این مخزن") را ببینید.
### ساخت تمامی فایل ها مورد نیاز یک Aggregate در کل ساختار پروژه برای دانلود و اظلاعات بیشتر [این مخزن](https://github.com/MicroDomainFlow/AutoMDF "این مخزن") را ببینید.


------------

نحوه استفاده و صحت عملکرد این پروژه، در[ پروژه Sample](https://github.com/MicroDomainFlow/Sample " پروژه Sample") آورده شده است. در اصل این دو پروژه در کنار هم دیگر هستند که در اینجا به عنوان مخازن جدا آورده شده اند.


## پکیج ها:

[MicroDomainFlow.BaseFramework](https://www.nuget.org/packages/MicroDomainFlow.BaseFramework "MicroDomainFlow.BaseFramework")

[MicroDomainFlow.BaseResources](https://www.nuget.org/packages/MicroDomainFlow.BaseResources "MicroDomainFlow.BaseResources")
