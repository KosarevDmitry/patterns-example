Tree 
[]<D:\src\runtime\src\libraries\System.Private.CoreLib\src\System\Threading\ThreadLocal.cs>

```csharp
      /// <summary>
    /// A wrapper struct used as LinkedSlotVolatile[] - an array of LinkedSlot instances, but with volatile semantics
    /// on array accesses.
    /// </summary>
    private struct LinkedSlotVolatile
    {
        internal volatile LinkedSlot? Value;
    }

    /// <summary>
    /// A node in the doubly-linked list stored in the ThreadLocal instance.
    ///
    /// The value is stored in one of two places:
    ///
    ///     1. If SlotArray is not null, the value is in SlotArray.Table[id]
    ///     2. If SlotArray is null, the value is in FinalValue.
    /// </summary>
    private sealed class LinkedSlot
    {
        internal LinkedSlot(LinkedSlotVolatile[]? slotArray)
        {
            _slotArray = slotArray;
        }

        // The next LinkedSlot for this ThreadLocal<> instance
        internal volatile LinkedSlot? _next;

        // The previous LinkedSlot for this ThreadLocal<> instance
        internal volatile LinkedSlot? _previous;

        // The SlotArray that stores this LinkedSlot at SlotArray.Table[id].
        internal volatile LinkedSlotVolatile[]? _slotArray;

        // The value for this slot.
        internal T? _value;
    }
```