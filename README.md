# median_filter
Удаление шумов изображении
# Практика «Медианный фильтр»

Перед преобразованием в черно-белое, с изображения лучше бы удалить шум.

Для этого обработайте его так называемым медианным фильтром. Каждый пиксель изображения нужно заменить медианой всех пикселей в 1-окрестности этого пикселя. То есть для внутреннего пикселя, это будет медиана 9 значений. А для углового — медиана 4 значений.

Медианой массива называется значение элемента, который окажется точно посередине после сортировки массива по возрастанию. Медианой четного количества значений для определённости считайте среднее арифметическое двух значений посередине отсортированного массива.

Выполните эту задачу в файле MedianFilterTask.cs
