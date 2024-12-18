﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Alternet.UI
{
    /// <summary>
    /// Implements delayed event.
    /// </summary>
    /// <typeparam name="TArgs">Type of the event argument.</typeparam>
    public struct DelayedEvent<TArgs> : IDisposable
    {
        private Timer? timer;

        /// <summary>
        /// Occurs when delayed event handlers are notified.
        /// </summary>
        public event EventHandler<TArgs> Delayed;

        /// <summary>
        /// Adds event handler.
        /// </summary>
        /// <param name="evt">Event handler.</param>
        public void Add(EventHandler<TArgs> evt)
        {
            Delayed += evt;
        }

        /// <summary>
        /// Removes event handler.
        /// </summary>
        /// <param name="evt">Event handler.</param>
        public void Remove(EventHandler<TArgs> evt)
        {
            Delayed -= evt;
        }

        /// <summary>
        /// Raises delayed event.
        /// </summary>
        /// <param name="sender">Sender of the event.</param>
        /// <param name="e">Event arguments.</param>
        /// <param name="isSuspended">Whether event is suspended (will not be called).</param>
        public void Raise(object? sender, TArgs e, Func<bool> isSuspended)
        {
            if (Delayed is not null)
            {
                var self = this;
                timer ??= new();
                timer.Stop();
                timer.Interval = TimerUtils.DefaultDelayedTextChangedTimeout;
                timer.TickAction = () =>
                {
                    if (isSuspended())
                        return;
                    self.Delayed?.Invoke(sender, e);
                };
                timer.StartOnce();
            }
        }

        /// <inheritdoc/>
        public void Dispose()
        {
            BaseObject.SafeDispose(ref timer);
        }
    }
}
