using System.Data;

namespace JournalEntry.Domain.Utilities
{
    public static class ReturnException
    {
        public static Exception getException(string type, string message)
        {
            return type.Equals("accessViolationException") ? accessViolationException(message) :
                type.Equals("aggregateException") ? aggregateException(message) :
                type.Equals("appDomainUnloadedException") ? appDomainUnloadedException(message) :
                type.Equals("applicationException") ? applicationException(message) :
                type.Equals("argumentNullException") ? argumentNullException(message) :
                type.Equals("argumentOutOfRangeException") ? argumentOutOfRangeException(message) :
                type.Equals("arithmeticException") ? arithmeticException(message) :
                type.Equals("arrayTypeMismatchException") ? arrayTypeMismatchException(message) :
                type.Equals("badImageFormatException") ? badImageFormatException(message) :
                type.Equals("cannotUnloadAppDomainException") ? cannotUnloadAppDomainException(message) :
                type.Equals("contextMarshalException") ? contextMarshalException(message) :
                type.Equals("dataMisalignedException") ? dataMisalignedException(message) :
                type.Equals("divideByZeroException") ? divideByZeroException(message) :
                type.Equals("dllNotFoundException") ? dllNotFoundException(message) :
                type.Equals("duplicateWaitObjectException") ? duplicateWaitObjectException(message) :
                type.Equals("entryPointNotFoundException") ? entryPointNotFoundException(message) :
                type.Equals("fieldAccessException") ? fieldAccessException(message) :
                type.Equals("formatException") ? formatException(message) :
                type.Equals("indexOutOfRangeException") ? indexOutOfRangeException(message) :
                type.Equals("insufficientMemoryException") ? insufficientMemoryException(message) :
                type.Equals("invalidCastException") ? invalidCastException(message) :
                type.Equals("invalidOperationException") ? invalidOperationException(message) :
                type.Equals("invalidProgramException") ? invalidProgramException(message) :
                type.Equals("invalidTimeZoneException") ? invalidTimeZoneException(message) :
                type.Equals("memberAccessException") ? memberAccessException(message) :
                type.Equals("methodAccessException") ? methodAccessException(message) :
                type.Equals("missingFieldException") ? missingFieldException(message) :
                type.Equals("missingMemberException") ? missingMemberException(message) :
                type.Equals("missingMethodException") ? missingMethodException(message) :
                type.Equals("multicastNotSupportedException") ? multicastNotSupportedException(message) :
                type.Equals("notFiniteNumberException") ? notFiniteNumberException(message) :
                type.Equals("notImplementedException") ? notImplementedException(message) :
                type.Equals("notSupportedException") ? notSupportedException(message) :
                type.Equals("nullReferenceException") ? nullReferenceException(message) :
                type.Equals("objectDisposedException") ? objectDisposedException(message) :
                type.Equals("operationCanceledException") ? operationCanceledException(message) :
                type.Equals("outOfMemoryException") ? outOfMemoryException(message) :
                type.Equals("overflowException") ? overflowException(message) :
                type.Equals("platformNotSupportedException") ? platformNotSupportedException(message) :
                type.Equals("rankException") ? rankException(message) :
                type.Equals("stackOverflowException") ? stackOverflowException(message) :
                type.Equals("systemException") ? systemException(message) :
                type.Equals("timeoutException") ? timeoutException(message) :
                type.Equals("timeZoneNotFoundException") ? timeZoneNotFoundException(message) :
                type.Equals("typeAccessException") ? typeAccessException(message) :
                type.Equals("typeLoadException") ? typeLoadException(message) :
                type.Equals("typeUnloadedException") ? typeUnloadedException(message) :
                type.Equals("unauthorizedAccessException") ? unauthorizedAccessException(message) :
                type.Equals("uriFormatException") ? uriFormatException(message) :
                type.Equals("constraintException") ? constraintException(message) :
                type.Equals("dataException") ? dataException(message) :
                type.Equals("dbConcurrencyException") ? dbConcurrencyException(message) :
                type.Equals("duplicateNameException") ? duplicateNameException(message) :
                type.Equals("evaluateException") ? evaluateException(message) :
                type.Equals("inRowChangingEventException") ? inRowChangingEventException(message) :
                type.Equals("invalidConstraintException") ? invalidConstraintException(message) :
                type.Equals("invalidExpressionException") ? invalidExpressionException(message) :
                type.Equals("missingPrimaryKeyException") ? missingPrimaryKeyException(message) :
                type.Equals("noNullAllowedException") ? noNullAllowedException(message) :
                type.Equals("readOnlyException") ? readOnlyException(message) :
                type.Equals("rowNotInTableException") ? rowNotInTableException(message) :
                type.Equals("strongTypingException") ? strongTypingException(message) :
                type.Equals("syntaxErrorException") ? syntaxErrorException(message) :
                type.Equals("versionNotFoundException") ? versionNotFoundException(message) :
                type.Equals("directoryNotFoundException") ? directoryNotFoundException(message) :
                type.Equals("driveNotFoundException") ? driveNotFoundException(message) :
                type.Equals("endOfStreamException") ? endOfStreamException(message) :
                type.Equals("fileNotFoundException") ? fileNotFoundException(message) :
                type.Equals("internalBufferOverflowException") ? internalBufferOverflowException(message) :
                type.Equals("invalidDataException") ? invalidDataException(message) :
                type.Equals("ioException") ? ioException(message) : pathTooLongException(message);
        }
        public static Exception accessViolationException(string message) => new AccessViolationException(message);
        public static Exception aggregateException(string message) => new AggregateException(message);
        public static Exception appDomainUnloadedException(string message) => new AppDomainUnloadedException(message);
        public static Exception applicationException(string message) => new ApplicationException(message);
        public static Exception argumentNullException(string message) => new ArgumentNullException(message);
        public static Exception argumentOutOfRangeException(string message) => new ArgumentOutOfRangeException(message);
        public static Exception arithmeticException(string message) => new ArithmeticException(message);
        public static Exception arrayTypeMismatchException(string message) => new ArrayTypeMismatchException(message);
        public static Exception badImageFormatException(string message) => new BadImageFormatException(message);
        public static Exception cannotUnloadAppDomainException(string message) => new CannotUnloadAppDomainException(message);
        public static Exception contextMarshalException(string message) => new ContextMarshalException(message);
        public static Exception dataMisalignedException(string message) => new DataMisalignedException(message);
        public static Exception divideByZeroException(string message) => new DivideByZeroException(message);
        public static Exception dllNotFoundException(string message) => new DllNotFoundException(message);
        public static Exception duplicateWaitObjectException(string message) => new DuplicateWaitObjectException(message);
        public static Exception entryPointNotFoundException(string message) => new EntryPointNotFoundException(message);
        //public static Exception executionEngineException(string message) => new ExecutionEngineException(message);
        public static Exception fieldAccessException(string message) => new FieldAccessException(message);
        public static Exception formatException(string message) => new FormatException(message);
        public static Exception indexOutOfRangeException(string message) => new IndexOutOfRangeException(message);
        public static Exception insufficientMemoryException(string message) => new InsufficientMemoryException(message);
        public static Exception invalidCastException(string message) => new InvalidCastException(message);
        public static Exception invalidOperationException(string message) => new InvalidOperationException(message);
        public static Exception invalidProgramException(string message) => new InvalidProgramException(message);
        public static Exception invalidTimeZoneException(string message) => new InvalidTimeZoneException(message);
        public static Exception memberAccessException(string message) => new MemberAccessException(message);
        public static Exception methodAccessException(string message) => new MethodAccessException(message);
        public static Exception missingFieldException(string message) => new MissingFieldException(message);
        public static Exception missingMemberException(string message) => new MissingMemberException(message);
        public static Exception missingMethodException(string message) => new MissingMethodException(message);
        public static Exception multicastNotSupportedException(string message) => new MulticastNotSupportedException(message);
        //public static Exception notCancelableException(string message) => new NotCancelableException(message);
        public static Exception notFiniteNumberException(string message) => new NotFiniteNumberException(message);
        public static Exception notImplementedException(string message) => new NotImplementedException(message);
        public static Exception notSupportedException(string message) => new NotSupportedException(message);
        public static Exception nullReferenceException(string message) => new NullReferenceException(message);
        public static Exception objectDisposedException(string message) => new ObjectDisposedException(message);
        public static Exception operationCanceledException(string message) => new OperationCanceledException(message);
        public static Exception outOfMemoryException(string message) => new OutOfMemoryException(message);
        public static Exception overflowException(string message) => new OverflowException(message);
        public static Exception platformNotSupportedException(string message) => new PlatformNotSupportedException(message);
        public static Exception rankException(string message) => new RankException(message);
        public static Exception stackOverflowException(string message) => new StackOverflowException(message);
        public static Exception systemException(string message) => new SystemException(message);
        public static Exception timeoutException(string message) => new TimeoutException(message);
        public static Exception timeZoneNotFoundException(string message) => new TimeZoneNotFoundException(message);
        public static Exception typeAccessException(string message) => new TypeAccessException(message);
        //public static Exception typeInitializationException(string message) => new TypeInitializationException(message);
        public static Exception typeLoadException(string message) => new TypeLoadException(message);
        public static Exception typeUnloadedException(string message) => new TypeUnloadedException(message);
        public static Exception unauthorizedAccessException(string message) => new UnauthorizedAccessException(message);
        public static Exception uriFormatException(string message) => new UriFormatException(message);
        public static Exception constraintException(string message) => new ConstraintException(message);
        public static Exception dataException(string message) => new DataException(message);
        public static Exception dbConcurrencyException(string message) => new DBConcurrencyException(message);
        //public static Exception deleteRowInaccessibleException(string message) => new DeleteRowInaccessibleException(message);
        public static Exception duplicateNameException(string message) => new DuplicateNameException(message);
        public static Exception evaluateException(string message) => new EvaluateException(message);
        public static Exception inRowChangingEventException(string message) => new InRowChangingEventException(message);
        public static Exception invalidConstraintException(string message) => new InvalidConstraintException(message);
        public static Exception invalidExpressionException(string message) => new InvalidExpressionException(message);
        public static Exception missingPrimaryKeyException(string message) => new MissingPrimaryKeyException(message);
        public static Exception noNullAllowedException(string message) => new NoNullAllowedException(message);
        //public static Exception operationAbortedException(string message) => new OperationAbortedException(message);
        public static Exception readOnlyException(string message) => new ReadOnlyException(message);
        public static Exception rowNotInTableException(string message) => new RowNotInTableException(message);
        public static Exception strongTypingException(string message) => new StrongTypingException(message);
        public static Exception syntaxErrorException(string message) => new SyntaxErrorException(message);
        //public static Exception syntaxErrorException(string message) => new TypedDataSetGeneratorException(message);
        public static Exception versionNotFoundException(string message) => new VersionNotFoundException(message);
        public static Exception directoryNotFoundException(string message) => new DirectoryNotFoundException(message);
        public static Exception driveNotFoundException(string message) => new DriveNotFoundException(message);
        public static Exception endOfStreamException(string message) => new EndOfStreamException(message);
        //public static Exception fileFormatException(string message) => new FileFormatException(message);
        public static Exception fileNotFoundException(string message) => new FileNotFoundException(message);
        public static Exception internalBufferOverflowException(string message) => new InternalBufferOverflowException(message);
        public static Exception invalidDataException(string message) => new InvalidDataException(message);
        public static Exception ioException(string message) => new IOException(message);
        public static Exception pathTooLongException(string message) => new PathTooLongException(message);
        //public static Exception pipeException(string message) => new PipeException(message);
    }
}