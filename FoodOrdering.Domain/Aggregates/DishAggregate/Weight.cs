using FoodOrdering.Domain.Common;

namespace FoodOrdering.Domain.Aggregates.DishAggregate
{
    public enum MeasurementUnit { Grams, Kilograms, Liters }
    public class Weight : ValueObject
    {
        public MeasurementUnit MesurementUnit { get; private set; }

        public double Value { get; private set; }

        public Weight() { }
        public Weight(double value, int measurementUnit)
        {
            MesurementUnit = (MeasurementUnit)measurementUnit;
            Value = value;
        }

    }
}
