using System;
using System.Collections.Generic;
using System.Text;

namespace FundooNoteSubscriber.Interface
{
    public interface IRabbitMQSubscriber
    {
        void ConsumeMessages();
    }
}
