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
    {"Correct option", "Togri variant"},
    {"Selected option", "Tanlangan variant"},
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
    {"Selected option", "Selected option"},
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
    {"Selected option", "Выбранный вариант"},
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


List<string[]> questions = new List<string[]>();
List<User> statistics = new List<User>()
{
    new User("men", 100),
    new User("jfa", 20),
    new User("kimdir", 40)
};

string password = "123asd";

AddDefaultQuestions(questions);

Start();

void ChooseMenu()
{
    var input = (Menu)int.Parse(Console.ReadLine()!);

    switch (input)
    {
        case Menu.StartQuiz: StartQuiz(); break;
        case Menu.AddQuestion: AddQuestion(); break;
        case Menu.Dashboard: Dashboard(); break;
        case Menu.Statistics: Statistics(); break;
        case Menu.Close: return;
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
    var input = (Language)int.Parse(Console.ReadLine()!);

    switch (input)
    {
        case Language.Uzbek: language = uzbekDictionary; break;
        case Language.English: language = englishDictionary; break;
        case Language.Russian: language = russianDictionary; break;
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
    var name = Console.ReadLine()!;
    int togriJavoblarSoni = 0;

    List<List<string>> notogrijavoblar = new List<List<string>>();

    for (var j = 0; j < questions.Count; j++)
    {
        for (var i = 0; i < questions[j].Length; i++)
        {
            if (i == 0) Console.WriteLine($"{language["Question"]} : {questions[j][i]}");
            else if (i != 1) Console.WriteLine($"{i - 1}. {questions[j][i]}");
        }

        Console.Write($"{language["Enter answer"]} : ");
        var answer = int.Parse(Console.ReadLine()!) + 1;

        if (answer.ToString() == questions[j][1])
        {
            togriJavoblarSoni++;
            Console.WriteLine($"{language["Correct answer"]}");
        }
        else
        {
            var list = new List<string>()
            {
                questions[j][0], (int.Parse(questions[j][1]) - 1).ToString(), (answer - 1).ToString()
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
            Console.WriteLine($"{notogriJavob[0]}\n{language["Correct option"]} = {notogriJavob[1]} {language["Selected option"]} = {notogriJavob[2]}");
        }
    }
    else
    {
        Console.WriteLine($"{language["All answers are correct"]}.");
    }

    var user = new User(name, (int)((double)togriJavoblarSoni / questions.Count * 100));
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
    var choices = new string[numberOfChoices];

    for (int i = 0; i < numberOfChoices; i++)
    {
        Console.Write($"{i + 1}. ");
        choices[i] = Console.ReadLine()!;
    }

    Console.Write($"{language["Enter index of correct answer"]} : ");
    var correctAnswerIndex = int.Parse(Console.ReadLine()!) + 1;

    var savol = new string[2 + choices.Length];
    savol[0] = newQuestion;
    savol[1] = correctAnswerIndex.ToString();

    for (var i = 0; i < choices.Length; i++)
    {
        savol[i + 2] = choices[i];
    }
    questions.Add(savol);

    Console.WriteLine($"{language["Question added"]}.");
    Start();
}

void Dashboard()
{
    Console.WriteLine($"{language["Number of available questions"]} {questions.Count}");

    foreach (var question in questions)
        Console.WriteLine(question[0]);

    Start();
}

void Statistics()
{
    Console.WriteLine($"{language["Statistics"]}.");
    ShowMenuStatistics();

    var input = (Menu)(int.Parse(Console.ReadLine()!) + 5);
    switch (input)
    {
        case Menu.Show: ShowStatistics(); break;
        case Menu.Clear: ClearStatistics(); break;
    }

    void ShowStatistics()
    {
        if (statistics!.Count > 0)
        {
            statistics = statistics.OrderByDescending(element => element.Answers).ToList();
            for (var i = 0; i < statistics.Count; i++)
            {
                var user = statistics[i];
                Console.WriteLine($"{i + 1}. {user.Name} {user.Answers}%");
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

void AddDefaultQuestions(List<string[]> questions)
{
    questions.Add(new[] { "2 + 4 = ?", "2", "6", "5", "7" });
    questions.Add(new[] { "2 * 4 = ?", "4", "6", "5", "8" });
    questions.Add(new[] { "8 / 4 = ?", "3", "6", "2", "7" });
    questions.Add(new[] { "5 % 4 = ?", "2", "1", "5", "7" });
}

void Start()
{
    Console.WriteLine();
    ShowLanguage(Language.Uzbek);
    ShowLanguage(Language.English);
    ShowLanguage(Language.Russian);
    ChooseLanguage();

    Console.WriteLine();
    ShowMenu(Menu.StartQuiz);
    ShowMenu(Menu.AddQuestion);
    ShowMenu(Menu.Dashboard);
    ShowMenu(Menu.Statistics);
    ShowMenu(Menu.Close);

    ChooseMenu();
}

void ShowMenuStatistics()
{
    Console.WriteLine();
    ShowMenu(Menu.Show, 5);
    ShowMenu(Menu.Clear, 5);
}

void ShowMenu(Menu menu, int i = 0)
{
    Console.WriteLine($"{(int)menu - i}. {menu}");
}

void ShowLanguage(Language language)
{
    Console.WriteLine($"{(int)language}. {language}");
}

struct User
{
    public string Name;
    public int Answers;

    public User(string name, int answers)
    {
        Name = name;
        Answers = answers;
    }
}

enum Menu
{
    StartQuiz = 1,
    AddQuestion,
    Dashboard,
    Statistics,
    Close,
    Show,
    Clear
}

enum Language
{
    Uzbek = 1,
    English,
    Russian
}