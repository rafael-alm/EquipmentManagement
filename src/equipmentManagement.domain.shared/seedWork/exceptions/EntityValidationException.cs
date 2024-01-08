﻿using equipmentManagement.domain.shared.seedWork.notification;

namespace equipmentManagement.domain.shared.seedWork.exceptions
{
    public class EntityValidationException : AggregateException
    {
        public IEnumerable<IMessageNotification> MessagesNotification { get; init; }

        public EntityValidationException(string message) : base(message)
            => MessagesNotification = new List<IMessageNotification>();

        public EntityValidationException(string message, IEnumerable<Exception> innerExceptions)
             : base(message, innerExceptions)
            => MessagesNotification = new List<IMessageNotification>();

        public EntityValidationException(string? message, IEnumerable<IMessageNotification> messagesNotification)
             : base(message)
            => MessagesNotification = messagesNotification;
    }
}
