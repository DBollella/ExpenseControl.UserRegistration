using System.Collections.Generic;

namespace ExpenseControl.UserRegistration.Application.Common
{
    public class Result
    {
        protected Result()
        {
            Messages = new HashSet<string>();
        }

        protected Result(string message) : this()
        {
            Messages.Add(message);
        }

        protected Result(IEnumerable<string> messages) : this()
        {
            Messages.UnionWith(messages);
        }

        public ISet<string> Messages { get; }

        public bool IsFailure => !IsSuccess;

        public bool IsSuccess => Messages.Count == 0;

        public static Result Ok()
        {
            return new Result();
        }

        public static Result Fail(string message)
        {
            return new Result(message);
        }

        public static Result Fail(IEnumerable<string> messages)
        {
            return new Result(messages);
        }
    }

    public class Result<TValue> : Result
    {
        private Result(string message)
            : base(message) { }

        private Result(IEnumerable<string> messages)
            : base(messages) { }

        public Result(TValue value)
        {
            Value = value;
        }

        public TValue Value { get; }

        public static Result<TValue> Ok(TValue value) => new Result<TValue>(value);

        public new static Result<TValue> Fail(string messages) => new Result<TValue>(messages);

        public new static Result<TValue> Fail(IEnumerable<string> messages) => new Result<TValue>(messages);

        public Result<TValue> Success(TValue value) => Ok(value);

        public Result<TValue> Error(string messsage) => Fail(messsage);

        public Result<TValue> Error(IEnumerable<string> messsages) => Fail(messsages);
    }
}


