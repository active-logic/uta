using NUnit.Framework;

namespace Unit{
public class LoggerTest : TestBase{

    [Test] public void Message () => log.message = "Message";
    [Test] public void Warning () => log.warning = "Warn";
    [Test] public void Error   () => log.error = "Error";

}}
