#  OrderApiApplication
## Описание 
Приложение для взаимодействия с облачной бд Товары и заказы, базовыми CRUD операциями и приминением JWT токена для проверки аутентификации. 

## Инструкция 
- ссылка на приложение https://orderapiapplication-kaine.amvera.io
 ___
### Клиенты
При работе с клиентами реализовано применение JWT токена. Необходимо перейти на **/login/{username}** где username ваш логин и получить токен. После добавлять его в запросы _прим_ **/client/all/"ваш токен"**
- **/client/all** -Получение всех клиентов 
- **/client/add** - Добавить клиента(JSON файлом через postman)
- **/client/get?id="idКлиента"** - Получение клиента по id
- **/client/update** - Обновление клиента (JSON файлом через postman)
- **/client/delete?id="idКлиента"** - Удаление клиента по id

### Заказы

- **/order/all** -Получение всех заказов 
- **/order/add** - Добавить заказ (JSON файлом через postman)
- **/order/get?id="idЗаказа"** - Получение заказа по id
- **/order/update** - Обновление заказа (JSON файлом через postman)
- **/order/delete?id="idЗаказа"** - Удаление заказа по id

### Товары

- **/product/all** -Получение всех Товаров
- **/product/add** - Добавить товар (JSON файлом через postman)
- **/product/get?id="idТовара"** - Получение товара по id
- **/product/update** - Обновление товара (JSON файлом через postman)
- **/product/delete?id="idТовара"** - Удаление товара по id

### Расшивка (Товар-Заказ)

- **/orderproduct/all** -Получение всех Товар-Заказов
- **/orderproduct/add** - Добавить Товар-Заказ (JSON файлом через postman)
- **/orderproduct/get?id="idТовар-Заказа"** - Получение Товар-Заказа по id
- **/orderproduct/update** - Обновление Товар-Заказа (JSON файлом через postman)
- **/orderproduct/delete?id="idТовар-Заказа"** - Удаление Товар-Заказа по id

## Чек

- **/check?orderId="idЗаказа"** -чек
