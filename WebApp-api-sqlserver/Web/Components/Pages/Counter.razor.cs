﻿using Microsoft.AspNetCore.Components;

namespace Web.Components.Pages;

public class CounterBase : ComponentBase
{
    protected int currentCount = 0;

    protected void IncrementCount()
    {
        currentCount++;
    }
}