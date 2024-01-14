using System;
using System.CommandLine;
using System.CommandLine.Binding;
using System.CommandLine.Invocation;
using System.CommandLine.Parsing;

namespace UntabifyTextFiles.Console.Extensions;

public static class ConsoleArgumentsEx
{
    public static Command FactoryAddCommand(this Command target, Command command)
    {
        target.AddCommand(command);
        return target;
    }
    public static Command FactoryAddAlias(this Command target, string alias)
    {
        target.AddAlias(alias);
        return target;
    }
    public static Command FactoryAddArgument<T>(this Command target, Argument<T> argument)
    {
        target.AddArgument(argument);
        return target;
    }
    public static Command FactoryAddGlobalOption(this Command target, Option option)
    {
        target.AddGlobalOption(option);
        return target;
    }
    public static Command FactoryAddOption(this Command target, Option option)
    {
        target.AddOption(option);
        return target;
    }
    public static Command FactoryAddValidator(this Command target, ValidateSymbolResult<CommandResult> validator)
    {
        target.AddValidator(validator);
        return target;
    }

    // ----------------------------------

    public static Command FactoryAdd(this Command target, Command command)
    {
        target.AddCommand(command);
        return target;
    }
    public static Command FactoryAdd(this Command target, string alias)
    {
        target.AddAlias(alias);
        return target;
    }
    public static Command FactoryAdd<T>(this Command target, Argument<T> argument)
    {
        target.AddArgument(argument);
        return target;
    }
    public static Command FactoryAdd(this Command target, Option option)
    {
        target.AddOption(option);
        return target;
    }
    public static Command FactoryAdd(this Command target, ValidateSymbolResult<CommandResult> validator)
    {
        target.AddValidator(validator);
        return target;
    }

    // ----------------------------------

    /// <summary>
    /// Sets a command's handler based on an <see cref="Action{InvocationContext}"/>.
    /// </summary>
    public static Command FactorySetHandler(
        this Command command,
        Action<InvocationContext> handle)
    {
        command.SetHandler(handle);
        return command;
    }

    /// <summary>
    /// Sets a command's handler based on an <see cref="Action"/>.
    /// </summary>
    public static Command FactorySetHandler(
        this Command command,
        Action handle)
    {
        command.SetHandler(handle);
        return command;
    }

    /// <summary>
    /// Sets a command's handler based on an <see cref="Action{T}"/>.
    /// </summary>
    public static Command FactorySetHandler<T>(
        this Command command,
        Action<T> handle,
        IValueDescriptor<T> symbol)
    {
        command.SetHandler(handle, symbol);
        return command;
    }

    /// <summary>
    /// Sets a command's handler based on an <see cref="Action{T1,T2}"/>.
    /// </summary>
    public static Command FactorySetHandler<T1, T2>(
        this Command command,
        Action<T1, T2> handle,
        IValueDescriptor<T1> symbol1,
        IValueDescriptor<T2> symbol2)
    {
        command.SetHandler(handle, symbol1, symbol2);
        return command;
    }

    /// <summary>
    /// Sets a command's handler based on an <see cref="Action{T1,T2,T3}"/>.
    /// </summary>
    public static Command FactorySetHandler<T1, T2, T3>(
        this Command command,
        Action<T1, T2, T3> handle,
        IValueDescriptor<T1> symbol1,
        IValueDescriptor<T2> symbol2,
        IValueDescriptor<T3> symbol3)
    {
        command.SetHandler(handle, symbol1, symbol2, symbol3);
        return command;
    }

    /// <summary>
    /// Sets a command's handler based on an <see cref="Action{T1,T2,T3,T4}"/>.
    /// </summary>
    public static Command FactorySetHandler<T1, T2, T3, T4>(
        this Command command,
        Action<T1, T2, T3, T4> handle,
        IValueDescriptor<T1> symbol1,
        IValueDescriptor<T2> symbol2,
        IValueDescriptor<T3> symbol3,
        IValueDescriptor<T4> symbol4)
    {
        command.SetHandler(handle, symbol1, symbol2, symbol3, symbol4);
        return command;
    }

    /// <summary>
    /// Sets a command's handler based on an <see cref="Action{T1,T2,T3,T4,T5}"/>.
    /// </summary>
    public static Command FactorySetHandler<T1, T2, T3, T4, T5>(
        this Command command,
        Action<T1, T2, T3, T4, T5> handle,
        IValueDescriptor<T1> symbol1,
        IValueDescriptor<T2> symbol2,
        IValueDescriptor<T3> symbol3,
        IValueDescriptor<T4> symbol4,
        IValueDescriptor<T5> symbol5)
    {
        command.SetHandler(handle, symbol1, symbol2, symbol3, symbol4, symbol5);
        return command;
    }

    /// <summary>
    /// Sets a command's handler based on an <see cref="Action{T1,T2,T3,T4,T5,T6}"/>.
    /// </summary>
    public static Command FactorySetHandler<T1, T2, T3, T4, T5, T6>(
        this Command command,
        Action<T1, T2, T3, T4, T5, T6> handle,
        IValueDescriptor<T1> symbol1,
        IValueDescriptor<T2> symbol2,
        IValueDescriptor<T3> symbol3,
        IValueDescriptor<T4> symbol4,
        IValueDescriptor<T5> symbol5,
        IValueDescriptor<T6> symbol6)
    {
        command.SetHandler(handle, symbol1, symbol2, symbol3, symbol4, symbol5, symbol6);
        return command;
    }

    /// <summary>
    /// Sets a command's handler based on an <see cref="Action{T1,T2,T3,T4,T5,T6,T7}"/>.
    /// </summary>
    public static Command FactorySetHandler<T1, T2, T3, T4, T5, T6, T7>(
        this Command command,
        Action<T1, T2, T3, T4, T5, T6, T7> handle,
        IValueDescriptor<T1> symbol1,
        IValueDescriptor<T2> symbol2,
        IValueDescriptor<T3> symbol3,
        IValueDescriptor<T4> symbol4,
        IValueDescriptor<T5> symbol5,
        IValueDescriptor<T6> symbol6,
        IValueDescriptor<T7> symbol7)
    {
        command.SetHandler(handle, symbol1, symbol2, symbol3, symbol4, symbol5, symbol6, symbol7);
        return command;
    }

    /// <summary>
    /// Sets a command's handler based on an <see cref="Action{T1,T2,T3,T4,T5,T6,T7,T8}"/>.
    /// </summary>
    public static Command FactorySetHandler<T1, T2, T3, T4, T5, T6, T7, T8>(
            this Command command,
            Action<T1, T2, T3, T4, T5, T6, T7, T8> handle,
            IValueDescriptor<T1> symbol1,
            IValueDescriptor<T2> symbol2,
            IValueDescriptor<T3> symbol3,
            IValueDescriptor<T4> symbol4,
            IValueDescriptor<T5> symbol5,
            IValueDescriptor<T6> symbol6,
            IValueDescriptor<T7> symbol7,
            IValueDescriptor<T8> symbol8)
    {
        command.SetHandler(handle, symbol1, symbol2, symbol3, symbol4, symbol5, symbol6, symbol7, symbol8);
        return command;
    }
}
