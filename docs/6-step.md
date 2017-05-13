MVC Tutorial
============

## Шаг 6 - шаблонные типы (generics) ##

В предыдущем шаге был сделан возврат результатов вычислений в виде модели данных. Для работы представления (точнее, в
методе `PrintResult()`) типом входных данных стал интерфейс `IDataModel`, для работы с данными результатов приходилось
преобразовывать тип объекта из интерфейса в нужный тип:
```cs
var model = result as DoubleModel;
if (model == null)
{
	Console.WriteLine("Неверный тип результата");
	return;
}
```

Для исправления указанного неудобства используем шаблонные типы вместо обычных интерфейсов. Шаблонные типы (также 
называемые обобщённые типы или универсальные типы) дают возможность использовать нужный производный тип в коде.
```cs
public interface ICalculator<TModel, TResult>: ICalculator 
    where TModel : IDataModel 
	where TResult : IDataModel
{
	TModel Model { get; }
	TResult Calc();
}
public interface ICalculationView<TModel, TResult> : ICalculationView
	where TModel : IDataModel 
	where TResult : IDataModel
{
	TModel GetModel();
	void PrintResult(TResult result);
}
```
Теперь в классах калькуляторов и представлений нужно указать конкретный используемый тип:
```cs
public class SquareRootView : ICalculationView<DoubleModel, DoubleModel>
{
	public DoubleModel GetModel()
	{
		// ...
	}

	public void PrintResult(DoubleModel model)
	{
		Console.WriteLine("Результат: {0}", model.Number);
	}
}
```
Теперь в этих классах используется нужный тип данных. Но такое решение половинчатое - такие классы нельзя добавить в
список `List<ICalculationView>` или `List<ICalculationView<IDataModel, IDataModel>>`. Это происходит, потому что C# не
может преобразовать тип `ICalculationView<DoubleModel, DoubleModel>` в тип `ICalculationView<IDataModel, IDataModel>`.

Решением будет использование двух интерфейсов вместе - обычный и шаблонный:
```cs
public interface ICalculator
{
	IDataModel Model { get; }
	IDataModel Calc();
}
public interface ICalculator<TModel, TResult>: ICalculator 
	where TModel : IDataModel 
	where TResult : IDataModel
{
	new TModel Model { get; }
	new TResult Calc();
}
```
И теперь элементы интерфейса `ICalculator` (обычного) нужно явно реализовать в абстрактном классе:
```cs
public abstract class AbstractCalculator<TModel, TResult> : ICalculator<TModel, TResult>
	where TModel : IDataModel 
	where TResult : IDataModel
{
	public abstract TModel Model { get; protected set; }
	public abstract TResult Calc();

	IDataModel ICalculator.Model
	{
		get { return Model; }
	}
	IDataModel ICalculator.Calc()
	{
		return Calc();
	}
}
```
Теперь контроллер может использовать новые классы представлений и калькуляторов, потому что внутри используются
шаблонные интерфейсы, а снаружи могут использоваться как нешаблонные.

### Класс `Computation` ###

Для удобства работы с несколькими расчётами сделан новый класс `Computation` ("вычислитель"), хранящий структуру
расчёта - название, тип для представления и тип калькулятора, и заменяющий статический класс `Calculator`. 
Использование вычислителя создаёт новый уровень абстракции архитектуры. Также использование вычислителя можно считать
элементом метапрограммирования - настройки кода записываются в конфигурацию, а контроллер выбирает нужные типы из этой
конфигурации.

[← Предыдущий шаг](5-step.md) | [Содержание](index.md) | [Следующий шаг →](7-step.md)
