namespace HitachiQA;

public interface IAutomationFactory<TAutomation>
{
    TAutomation CreateAutomation();
}