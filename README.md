### Библиотека генетического алгоритма С#
----
Генетический алгоритм
    :    это эвристический алгоритм поиска, используемый для решения задач оптимизации и моделирования путём случайного подбора, комбинирования и вариации искомых параметров с использованием механизмов, аналогичных естественному отбору в природе.
#### Используемые методы
1. Элитарный отбор новых особей
2. Метод рулетки для отбора родителей
3. Двуточечный кроссинговер
4. Бинарная мутация генома

##### Пример использования алгоритма
 __Инициализация класса генетического алгоритма__
``` CS
    GeneticAlgorithm geneticAlgorithm =new GeneticAlgorithm();
```
__Создание популяции для использования__

``` CS

    var population =new Population(
        РазмерПопуляции,
        КоличествоОсобей,
        КоличествоОсобейДляВыбора
        РазмерГеномаИндивида,
        ФитнесФункция
    );

```
__Создание фитнес функции для использования__
1. Необходимо создать свой класс фитнесс функции в котором необходимо реализивать метод ___GetFitness()__
__Пример:__
```CS
    public class FitnessFunction:IFitnessFunction
    {
        public float GetFitness(IChromosome chromosome)
        {
            float fitness = 0;
            for (int i = 0; i <chromosome.Genome.Length; i++)
                fitness += chromosome.Genome[i];
            return fitness;
        }
    }
```
2. Создать экземпляр вашего класса для добавления в популяцию
```CS
    var fitness = new FitnessFunction();
```
__Создание мутатора__
```CS
    var mutator = new Mutator(ШансМутации);
```
__Полный пример использования:__
```CS
var fitnes = new FitnessFunction();

var population = new Population(100,50,20,8,fitnes);

var mutator = new Mutator(0.05f);

GeneticAlgorithm geneticAlgorithm = new GeneticAlgorithm(population,mutator);
//Запуск эволюции
geneticAlgorithm.Evaluate();
//Вывод приспособленности самого лучшего индивида в популяции
Console.WriteLine(geneticAlgorithm.PopulationFitness);
// Печать набора хромосом лучшего индивида
Console.WriteLine(geneticAlgorithm.BestChromosome.ToString());
```
#### Используемые справочные материалы
1. ___Genetic Algorithm in Artificial Intelligence - The Math of Intelligence___
https://www.youtube.com/watch?v=rGWBo0JGf50

2. ___Панченко, Т.В. Генетические алгоритмы: учебно-методическое пособие / под ред. Ю.Ю. Тарасевича. - Астрахань: Издательнский дом "Астраханский университет", 2007.-87 [3] c.___

