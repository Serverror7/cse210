class EternalRequest : Quest
{
// Provide for eternal goals that are never complete, but each time the user records them, they gain some value.

    public override int EventRegister()
    {
    return GetScore();
    }
    public override string QuestToSave()
    {
        return $"ET␉{GetCompletion()}␉{GetName()}␉{GetDescription()}␉{GetScore()}";
    }
    // loadQuest works to load
    // passquest works to pass quest

}