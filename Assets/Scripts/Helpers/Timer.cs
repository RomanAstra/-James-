using System;

namespace Assets.Scripts.Helpers
{
    /// <summary>
    /// Класс "Таймер", отсчитывает время, если нужно
    /// </summary>
    [Serializable]
    public class Timer
    {
        private DateTime _start;
        private float _elapsed = -1;

        public TimeSpan Duration { get; private set; }
        /// <summary>
        /// Метод 'Update' у класса 'Timer', задает, сколько времени нужно отсчитать.
        /// </summary>
        /// <param name="elapsed">Кол-во времени для отсчета</param>
        public void Start(float elapsed)
        {
            _elapsed = elapsed;
            _start = DateTime.Now;
            Duration = TimeSpan.Zero;
        }
        /// <summary>
        /// Метод 'Update' у класса 'Timer', идет отсчет до нуля.
        /// </summary>
        public void Update()
        {
            if (_elapsed > 0)
            {
                Duration = DateTime.Now - _start;

                if (Duration.TotalSeconds > _elapsed)
                {
                    _elapsed = 0;
                }
            }
            else if (_elapsed == 0)
            {
                _elapsed = -1;
            }
        }
        /// <summary>
        /// Проверка - время вышло или нет.
        /// </summary>
        public bool IsEvent()
        {
            return _elapsed == 0;
        }

        public int TotalSeconds()
        {
            return (int)(_elapsed - Duration.TotalSeconds);
        }
    }
}