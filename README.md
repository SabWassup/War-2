# War-2
В программе реализован алгоритм создания армий разной заполняемости и размеров, также реализовано столкновение двух армий по следующей последовательности:
На каждом шагу выбранный юнит наносит урон здоровью противника (рандомно выбранного) на уровень своей силы либо лечит произвольных юнитов из своей армии: Лекарь – не более 1 юнита не более чем на 2 единицы здоровья; Лечащая башня – не более 3х юнитов, не более чем на 15 единиц здоровья за 1 ход. Первыми удар наностя рандомные юниты с максимальной инициативой (1 - max, 6 - min) - противник из противоположной армии выбирается рандомно. Следующий удар за юнитами, с инициативой меньшей предыдущих на 1: т.е. инициатива = 2, затем 3, 4, 5 и 6. Цикл повторяется пока какая-нибудь из армий не будет полностью убита. 
Результаты каждого хода записываются в файл.

Дополнительная информация:
* Уровень здоровья*:
- Воин – 5
- Кавалерия – 10
- Лучник – 3
- Конный лучник – 7
- Лекарь – 3
- Лечащая башня – 20
- Атакующая башня – 30
* Сила*:
- Воин – 2
- Кавалерия – 7
- Лучник – 3
- Конный лучник – 10
- Атакующая башня – 20
* Инициатива*:
- Башни имеют инициативу 1
- Конный лучник – 2
- Кавалерия – 3
- Лучник – 4
- Лекарь – 5
- Воин – 6
