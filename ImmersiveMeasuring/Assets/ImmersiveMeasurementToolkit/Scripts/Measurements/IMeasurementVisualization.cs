using MeasurementUtility;
using Util;

namespace Measurements
{
    public interface IMeasurementVisualization : IHoverable
    {
        public void UpdateMeasurement(Measurement measurement);

    }
}

