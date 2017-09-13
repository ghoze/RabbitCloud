﻿using Rabbit.Cloud.Facade.Abstractions.Filters;
using Rabbit.Cloud.Facade.Abstractions.Formatters;

namespace Rabbit.Cloud.Facade.Abstractions
{
    public class FacadeOptions
    {
        public FormatterCollection<IOutputFormatter> OutputFormatters { get; } = new FormatterCollection<IOutputFormatter>();
        public FormatterCollection<IInputFormatter> InputFormatters { get; } = new FormatterCollection<IInputFormatter>();

        public FilterCollection Filters { get; } = new FilterCollection();
    }
}