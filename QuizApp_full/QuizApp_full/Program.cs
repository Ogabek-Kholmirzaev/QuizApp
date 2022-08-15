Dictionary<string, string> uzbekDictionary = new Dictionary<string, string>()
{
    {"An unavailable Menu was selected", "Mavjud bolmagan Menu tanlandi"},
    {"Enter your name", "Ismingizni kiriting"},
    {"Question", "Savol"},
    {"Enter answer", "Javobini kiriting"},
    {"Correct answer", "Javob togri"},
    {"Wrong answer", "Javob notogri"},
    {"Click 'Enter' to see the result", "Natijani korish uchun 'Enter' bosing"},
    {"Click 'Enter' to continue", "Davom etish uchun 'Enter' bosing."},
    {"Number of correct answers", "Togri javoblar soni"},
    {"Wrong answers", "Notogri javoblar"},
    {"Your answer", "Sizning javobingiz"},
    {"Click 'Enter' for Menu", "Menu uchun 'Enter' bosing"},
    {"Enter password", "Parolni kiriting"},
    {"Wrong password", "Parol notogri"},
    {"Enter question", "Savolni kiriting"},
    {"Enter number of options", "Variantlar sonini kiriting"},
    {"Enter options", "Variantlarni kiriting"},
    {"Enter index of correct answer", "Togri javob indeksi kiriting"},
    {"Question added", "Savol qoshildi"},
    {"Number of available questions", "Mavjud savollar soni"},
    {"Statistics", "Statistika"},
    {"Nobody has solved yet", "Hech kim ishlamadi"},
    {"Cleared", "Tozalndi"},
    {"An unavailable language was selected", "Mavjud bo'lmagan til tanlandi"},
    {"All answers are correct", "Hamma javoblaringiz to'g'ri"}

};

Dictionary<string, string> englishDictionary = new Dictionary<string, string>()
{
    {"An unavailable Menu was selected", "An unavailable Menu was selected"},
    {"Enter your name", "Enter your name"},
    {"Question", "Question"},
    {"Enter answer", "Enter answer"},
    {"Correct answer", "Correct answer"},
    {"Wrong answer", "Wrong answer"},
    {"Click 'Enter' to see the result", "Click 'Enter' to see the result"},
    {"Click 'Enter' to continue", "Click 'Enter' to continue"},
    {"Number of correct answers", "Number of correct answers"},
    {"Wrong answers", "Wrong answers"},
    {"Correct option", "Correct option"},
    {"Your answer", "Your answer"},
    {"Click 'Enter' for Menu", "Click 'Enter' for Menu"},
    {"Enter password", "Enter password"},
    {"Wrong password", "Wrong password"},
    {"Enter question", "Enter question"},
    {"Enter number of options", "Enter number of options"},
    {"Enter options", "Enter options"},
    {"Enter index of correct answer", "Enter index of correct answer"},
    {"Question added", "Question added"},
    {"Number of available questions", "Number of available questions"},
    {"Statistics", "Statistics"},
    {"Nobody has solved yet", "Nobody has solved yet"},
    {"Cleared", "Cleared"},
    {"An unavailable language was selected", "An unavailable language was selected"},
    {"All answers are correct", "All answers are correct"}

};

Dictionary<string, string> russianDictionary = new Dictionary<string, string>()
{
    {"An unavailable Menu was selected", "Выбрано недоступное меню"},
    {"Enter your name", "Введите ваше имя"},
    {"Question", "Вопрос"},
    {"Enter answer", "Введите ответ"},
    {"Correct answer", "Правильный ответ"},
    {"Wrong answer", "Неправильный ответ"},
    {"Click 'Enter' to see the result", "Нажмите «Ввод», чтобы увидеть результат"},
    {"Click 'Enter' to continue", "Нажмите «Ввод», чтобы продолжить"},
    {"Number of correct answers", "Количество правильных ответов"},
    {"Wrong answers", "Неправильные ответы"},
    {"Correct option", "Правильный вариант"},
    {"Your answer", "ваш ответ"},
    {"Click 'Enter' for Menu", "Нажмите «Ввод» для меню"},
    {"Enter password", "Введите пароль"},
    {"Wrong password", "Неправильный пароль"},
    {"Enter question", "Введите вопрос"},
    {"Enter number of options", "Введите количество вариантов"},
    {"Enter options", "Введите варианты "},
    {"Enter index of correct answer", "Введите индекс правильного ответа"},
    {"Question added", "Вопрос добавлен"},
    {"Number of available questions", "Количество доступных вопросов"},
    {"Statistics", "Статистика"},
    {"Nobody has solved yet", "Никто еще не решил"},
    {"Cleared", "Очищено"},
    {"An unavailable language was selected", "Выбран недоступный язык"},
    {"All answers are correct", "Все ответы правильные"}
};

Dictionary<string, string> language = uzbekDictionary;


List<Question> questions = new List<Question>();


List<User> statistics = new List<User>()
{
    new User("men", 4, 4),
    new User("jfa", 2, 5),
    new User("kimdir", 3, 6)
};

string password = "123asd";

AddDefaultQuestions(questions);

Start();

void ChooseMenu()
{
    var input = (EMenu)int.Parse(Console.ReadLine()!);

    switch (input)
    {
        case EMenu.StartQuiz: StartQuiz(); break;
        case EMenu.AddQuestion: AddQuestion(); break;
        case EMenu.Dashboard: Dashboard(); break;
        case EMenu.Statistics: Statistics(); break;
        case EMenu.Close: return;
        default:
            {
                Console.WriteLine($"{language["An unavailable Menu was selected"]}.");
                Start();
            }
            break;
    }
}

void ChooseLanguage()
{
    var input = (ELanguage)int.Parse(Console.ReadLine()!);

    switch (input)
    {
        case ELanguage.Uzbek: language = uzbekDictionary; break;
        case ELanguage.English: language = englishDictionary; break;
        case ELanguage.Russian: language = russianDictionary; break;
        default:
        {
                Console.WriteLine($"{language["An unavailable language was selected"]}.");
            Start();
        } break;

    }
}

void StartQuiz()
{
    Console.Write($"{language["Enter your name"]} : ");
    string? name = Console.ReadLine();

    if(string.IsNullOrEmpty(name))
        Start();

    int togriJavoblarSoni = 0;

    List<List<string>> notogrijavoblar = new List<List<string>>();

    for (var j = 0; j < questions.Count; j++)
    {
        var question = questions[j];

        Console.WriteLine($"{language["Question"]} : {question.QuestionText}");
        
        for(int i = 0; i < question.Choices.Count; i++)
            Console.WriteLine($"{i + 1}. {question.Choices[i]}");
        
        Console.Write($"{language["Enter answer"]} : ");
        var answer = int.Parse(Console.ReadLine()!) - 1;

        if (answer == question.CorrectAnswerIndex)
        {
            togriJavoblarSoni++;
            Console.WriteLine($"{language["Correct answer"]}");
        }
        else
        {
            var list = new List<string>()
            {
                question.QuestionText, question.Choices[question.CorrectAnswerIndex], question.Choices[answer]
            };
            notogrijavoblar.Add(list);

            Console.WriteLine($"{language["Wrong answer"]}");
        }

        Console.WriteLine(questions.Count - 1 == j
            ? $"{language["Click 'Enter' to see the result"]}."
            : $"{language["Click 'Enter' to continue"]}.");

        Console.ReadKey();
    }

    Console.WriteLine($"{language["Number of correct answers"]} : {togriJavoblarSoni}");

    if (notogrijavoblar.Count > 0)
    {
        Console.WriteLine($"{language["Wrong answers"]}.");
        foreach (var notogriJavob in notogrijavoblar)
        {
            Console.WriteLine($"{notogriJavob[0]}   {language["Correct answer"]} = {notogriJavob[1]} {language["Your answer"]} = {notogriJavob[2]}");
        }
        // Dictionary : "Correct option" => "Correct answer" and "Your answer"
    }
    else
    {
        Console.WriteLine($"{language["All answers are correct"]}.");
    }

    var user = new User(name!, togriJavoblarSoni, questions.Count);
    statistics.Add(user);

    Console.WriteLine($"{language["Click 'Enter' for Menu"]}.");
    Console.ReadKey();
    Start();
}

void AddQuestion()
{
    Console.Write($"{language["Enter password"]} : ");
    var parol = Console.ReadLine();

    if (password != parol)
    {
        Console.WriteLine($"{language["Wrong password"]}");
        Start();
    }

    Console.WriteLine($"{language["Enter question"]}.");
    var newQuestion = Console.ReadLine()!;

    Console.Write($"{language["Enter number of options"]} : ");
    int numberOfChoices = int.Parse(Console.ReadLine()!);

    Console.WriteLine($"{language["Enter options"]}.");
    var choices = new List<string>();

    for (int i = 0; i < numberOfChoices; i++)
    {
        Console.Write($"{i + 1}. ");
        choices.Add(Console.ReadLine()!);
    }

    Console.Write($"{language["Enter index of correct answer"]} : ");
    var correctAnswerIndex = int.Parse(Console.ReadLine()!) - 1;

    var savol = new Question(newQuestion, correctAnswerIndex, choices);
    questions.Add(savol);

    Console.WriteLine($"{language["Question added"]}.");
    Start();
}

void Dashboard()
{
    Console.WriteLine($"{language["Number of available questions"]} {questions.Count}");

    int index = 0;

    foreach (var question in questions)
        Console.WriteLine($"{++index}. {question.QuestionText}");

    Start();
}

void Statistics()
{
    Console.WriteLine($"{language["Statistics"]}.");
    ShowMenuStatistics();

    var input = (EMenu)(int.Parse(Console.ReadLine()!) + 5);
    switch (input)
    {
        case EMenu.Show: ShowStatistics(); break;
        case EMenu.Clear: ClearStatistics(); break;
    }

    void ShowStatistics()
    {
        if (statistics!.Count > 0)
        {
            statistics = statistics.OrderByDescending(element => element.ToPercent()).ToList();
            for (var i = 0; i < statistics.Count; i++)
            {
                var user = statistics[i];
                Console.WriteLine($"{i + 1}. {user.Name} {user.ToStringPercent()}");
            }
        }
        else
            Console.WriteLine($"{language["Nobody has solved yet"]}.");

        Console.WriteLine($"{language["Click 'Enter' for Menu"]}.");
        Console.ReadKey();
        Start();
    }

    void ClearStatistics()
    {
        statistics.Clear();
        Console.WriteLine($"{language["Cleared"]}.");
        Start();
    }
}

void AddDefaultQuestions(List<Question> questions)
{
    questions.Add(new Question("2 + 4 = ?", 0, new List<string>() { "6", "5", "7" }));
    questions.Add(new Question("2 * 4 = ?", 2, new List<string>() { "6", "5", "8" }));
    questions.Add(new Question("8 / 4 = ?", 1, new List<string>() { "6", "2", "7" }));
    questions.Add(new Question("5 % 4 = ?", 0, new List<string>() { "1", "5", "7" }));
}

void Start()
{
    Console.WriteLine();
    ShowLanguage(ELanguage.Uzbek);
    ShowLanguage(ELanguage.English);
    ShowLanguage(ELanguage.Russian);
    ChooseLanguage();

    Console.WriteLine();
    ShowMenu(EMenu.StartQuiz);
    ShowMenu(EMenu.AddQuestion);
    ShowMenu(EMenu.Dashboard);
    ShowMenu(EMenu.Statistics);
    ShowMenu(EMenu.Close);

    ChooseMenu();
}

void ShowMenuStatistics()
{
    Console.WriteLine();
    ShowMenu(EMenu.Show, 5);
    ShowMenu(EMenu.Clear, 5);
}

void ShowMenu(EMenu menu, int i = 0)
{
    Console.WriteLine($"{(int)menu - i}. {menu}");
}

void ShowLanguage(ELanguage language)
{
    Console.WriteLine($"{(int)language}. {language}");
}