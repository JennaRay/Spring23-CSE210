using System;

class SensesActivity : Activity
{
    private Dictionary<string, string> _senses;
    public SensesActivity(string intro, string instructions) : base(intro, instructions)
    {
        _senses = new Dictionary<string, string>()
        {
            // sense -----------verb, special instructions
            {"Sight", "Keep your eyes open for this activity and focus on the different things you can see around you. Start by picking one thing and noticing all of its details, then when you're ready, move on to something else."},
            {"Sound", "Close your eyes if you're comfortable enough to do so and focus on the different things you can hear. What can you hear close to you? What do you hear thats far away or in the background; outside even. Notice each sound and then when you're ready, notice a different one"},
            {"Taste", "For this activity you can grab a snack, a drink, or go without. Close your eyes and pay close attention to how your mouth tastes. Is it all the same? Does it change? If you have a snack or drink, eat/drink it slowly and really pay attention to it's taste and texture."},
            {"Smell", "Close your eyes for this activity and focus on the different things you can smell. This could be the scent of the air, a nearby scented candle, maybe even yourself if you're wearing perfume or something of the sort. Notice and acknowledge each smell, then move to a different one when you're ready. If you feel like there aren't enough things to smell, you can also pay attention to the way the air feels as it travels through different parts of your body when inhaling and exhaling."},
            {"Touch", "Close your eyes for this activity and, without moving to touch things, focus on what you can currently physically feel. The different points of contact your body has with its surroundings, the air traveling through your nose, the breeze brushing your skin. Try not to add any emotion or opinion to each feeling, just acknowledge it and move one when you're ready."}
        };
    }

    public void Run()
    {
        StartActivity();
        string sense = PickSense();
        Console.WriteLine(_senses[sense]);
        Thread.Sleep(3000);
        DateTime startTime = DateTime.Now;
        DateTime futureTime = startTime.AddSeconds(_userTime);

        Thread.Sleep(100);

        DateTime currentTime = DateTime.Now;

        while (currentTime < futureTime)
        {
            currentTime = DateTime.Now;
            Pause(5000);
        }
        Console.WriteLine("Time's up!");

    }

    private string PickSense()
    {
        Console.WriteLine("Which of your five senses would you like to focus on?");
        foreach (var sense in _senses)
        {
            Console.WriteLine($"    {sense.Key}");
        }
        string answer = Console.ReadLine();
        return answer;
    }
}