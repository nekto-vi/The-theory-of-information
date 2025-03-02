using System;
using System.IO;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace lb1
{
    public partial class Form1: Form
    {
        private bool useColumnarMethod = false;
        private bool useVigenerMethod = false;
        private OpenFileDialog openFileDialog;
        private SaveFileDialog saveFileDialog;

        private string inputFilePath = null; 
        private string outputFilePath = null;
        private const string RussianAlphabet = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ";

        public Form1()
        {
            InitializeComponent();

            // Инициализация диалоговых окон
            openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";
            openFileDialog.Title = "Выберите файл для чтения";

            saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";
            saveFileDialog.Title = "Выберите файл для записи";
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        // Столбцовый метод (Method_1) галочка
        private void checkBox1_CheckedChanged_1(object sender, EventArgs e)
        {
            if (Method_1.Checked)
            {
                useColumnarMethod = true;
                Method_2.Checked = false; 
                useVigenerMethod = false;
            }
        }

        // Метод Виженера (Method_2) галочка
        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (Method_2.Checked)
            {
                useVigenerMethod = true;
                Method_1.Checked = false; 
                useColumnarMethod = false;
            }
        }
        // Окно ввода ключа (Key_to_read) окно
        private void Key_2_TextChanged(object sender, EventArgs e)
        {

        }

        // Шифровать (Encrypt) кнопка
        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(inputFilePath))
            {
                MessageBox.Show("Сначала выберите файл для чтения.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrEmpty(outputFilePath))
            {
                MessageBox.Show("Сначала выберите файл для записи.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!useColumnarMethod && !useVigenerMethod)
            {
                MessageBox.Show("Выберите метод шифрования.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string key = Key_to_read.Text.Trim();
            if (string.IsNullOrEmpty(key))
            {
                MessageBox.Show("Пожалуйста, введите ключевое слово.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            key = ValidateKey(key);
            if (key == null)
            {
                MessageBox.Show("Ключ должен состоять только из русских букв.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string plainText = File.ReadAllText(inputFilePath);
            plainText = FilterRussianLetters(plainText).ToUpper();

            string encryptedText = "";
            if (useColumnarMethod)
            {
                encryptedText = ColumnarTranspositionEncrypt(plainText, key);
            }
            else if (useVigenerMethod)
            {
                string generatedKey = GenerateAutokey(key, plainText);
                Key_to_use.Text = generatedKey; 
                encryptedText = VigenereEncrypt(plainText, generatedKey);
            }


            WriteResultToFile(encryptedText);

            End.Text = encryptedText;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Start.Text = string.Empty;
            End.Text = string.Empty;
            Key_to_read.Text = string.Empty;
            Key_to_use.Text = string.Empty;

            Method_1.Checked = false; 
            Method_2.Checked = false; 

            useColumnarMethod = false;
            useVigenerMethod = false;
        }

        // Дешифровать (Decrypt) кнопка
        private void Decrypt_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(inputFilePath))
            {
                MessageBox.Show("Сначала выберите файл для чтения.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrEmpty(outputFilePath))
            {
                MessageBox.Show("Сначала выберите файл для записи.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!useColumnarMethod && !useVigenerMethod)
            {
                MessageBox.Show("Выберите метод дешифрования.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string key = Key_to_read.Text.Trim();
            if (string.IsNullOrEmpty(key))
            {
                MessageBox.Show("Пожалуйста, введите ключевое слово.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            key = ValidateKey(key);
            if (key == null)
            {
                MessageBox.Show("Ключ должен состоять только из русских букв.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string encryptedText = File.ReadAllText(inputFilePath);
            encryptedText = FilterRussianLetters(encryptedText).ToUpper();

            string decryptedText = "";
            if (useColumnarMethod)
            {
                decryptedText = ColumnarTranspositionDecrypt(encryptedText, key);
            }
            else if (useVigenerMethod)
            {
                decryptedText = VigenereDecrypt(encryptedText, key);
                string generatedKey = key + decryptedText.Substring(0, encryptedText.Length - key.Length);
                Key_to_use.Text = generatedKey; 
            }

            WriteResultToFile(decryptedText);

            End.Text = decryptedText;
        }
        private void Start_TextChanged(object sender, EventArgs e)
        {
            Start.Text = FilterRussianLetters(Start.Text).ToUpper();
            Start.SelectionStart = Start.Text.Length; 
        }
        private void End_TextChanged(object sender, EventArgs e)
        {

        }

        private string ColumnarTranspositionEncrypt(string plainText, string key)
        {
            plainText = FilterRussianLetters(plainText).ToUpper();
            key = FilterRussianLetters(key).ToUpper();

            int keyLength = key.Length;
            int rowCount = (int)Math.Ceiling((double)plainText.Length / keyLength);
            char[,] table = new char[rowCount, keyLength];

            for (int i = 0; i < rowCount; i++)
            {
                for (int j = 0; j < keyLength; j++)
                {
                    int currentCharIndex = i * keyLength + j;
                    if (currentCharIndex < plainText.Length)
                    {
                        table[i, j] = plainText[currentCharIndex];
                    }
                    else
                    {
                        table[i, j] = ' ';
                    }
                }
            }

            var order = key.Select((c, index) => new { Char = c, Index = index })
                           .OrderBy(x => x.Char)
                           .Select(x => x.Index)
                           .ToList();

            string encryptedText = "";
            foreach (var columnIndex in order)
            {
                for (int i = 0; i < rowCount; i++)
                {
                    if (table[i, columnIndex] != ' ')
                    {
                        encryptedText += table[i, columnIndex];
                    }
                }
            }

            return encryptedText;
        }

        // дешифрирование столбцовый метод
        private string ColumnarTranspositionDecrypt(string encryptedText, string key)
        {
            encryptedText = FilterRussianLetters(encryptedText).ToUpper();
            key = FilterRussianLetters(key).ToUpper();

            int keyLength = key.Length;
            int rowCount = (int)Math.Ceiling((double)encryptedText.Length / keyLength);

            var order = key.Select((c, index) => new { Char = c, Index = index })
                           .OrderBy(x => x.Char)
                           .Select(x => x.Index)
                           .ToList();

            char[,] table = new char[rowCount, keyLength];

            int[] columnLengths = new int[keyLength];
            int totalChars = encryptedText.Length;
            for (int i = 0; i < keyLength; i++)
            {
                columnLengths[i] = totalChars / keyLength;
                if (i < totalChars % keyLength)
                {
                    columnLengths[i]++;
                }
            }

            int currentCharIndex = 0;
            foreach (var columnIndex in order)
            {
                for (int i = 0; i < columnLengths[columnIndex]; i++)
                {
                    if (currentCharIndex < encryptedText.Length)
                    {
                        table[i, columnIndex] = encryptedText[currentCharIndex++];
                    }
                }
            }

            string decryptedText = "";
            for (int i = 0; i < rowCount; i++)
            {
                for (int j = 0; j < keyLength; j++)
                {
                    if (table[i, j] != '\0')
                    {
                        decryptedText += table[i, j];
                    }
                }
            }

            return decryptedText;
        }

        private string GenerateAutokey(string initialKey, string text)
        {
            initialKey = initialKey.ToUpper();
            text = text.ToUpper();

            if (initialKey.Length >= text.Length)
            {
                return initialKey.Substring(0, text.Length);
            }

            StringBuilder fullKey = new StringBuilder(initialKey);
            int keyIndex = 0;

            while (fullKey.Length < text.Length)
            {
                fullKey.Append(text[keyIndex]);
                keyIndex++;
            }

            return fullKey.ToString();
        }

        // Шифрование методом Виженера
        private string VigenereEncrypt(string plainText, string key)
        {
            plainText = FilterRussianLetters(plainText).ToUpper();
            key = FilterRussianLetters(key).ToUpper();

            StringBuilder encryptedText = new StringBuilder();

            for (int i = 0; i < plainText.Length; i++)
            {
                char plainChar = plainText[i];
                char keyChar = key[i % key.Length];

                int plainIndex = RussianAlphabet.IndexOf(plainChar);
                int keyIndex = RussianAlphabet.IndexOf(keyChar);

                if (plainIndex != -1 && keyIndex != -1)
                {
                    int encryptedIndex = (plainIndex + keyIndex) % RussianAlphabet.Length;
                    encryptedText.Append(RussianAlphabet[encryptedIndex]);
                }
                else
                {
                    encryptedText.Append(plainChar);
                }
            }

            return encryptedText.ToString();
        }

        // Дешифрование методом Виженера
        private string VigenereDecrypt(string encryptedText, string initialKey)
        {
            encryptedText = FilterRussianLetters(encryptedText).ToUpper();
            initialKey = FilterRussianLetters(initialKey).ToUpper();

            StringBuilder decryptedText = new StringBuilder();
            StringBuilder key = new StringBuilder(initialKey);

            for (int i = 0; i < encryptedText.Length; i++)
            {
                char encryptedChar = encryptedText[i];
                char keyChar = key[i % key.Length];

                int encryptedIndex = RussianAlphabet.IndexOf(encryptedChar);
                int keyIndex = RussianAlphabet.IndexOf(keyChar);

                if (encryptedIndex != -1 && keyIndex != -1)
                {
                    int decryptedIndex = (encryptedIndex - keyIndex + RussianAlphabet.Length) % RussianAlphabet.Length;
                    char decryptedChar = RussianAlphabet[decryptedIndex];
                    decryptedText.Append(decryptedChar);

                    key.Append(decryptedChar);
                }
                else
                {
                    decryptedText.Append(encryptedChar);
                }
            }

            return decryptedText.ToString();
        }
        private string FilterRussianLetters(string input)
        {
            return Regex.Replace(input, "[^А-Яа-яЁё]", "");
        }

        private string ValidateKey(string key)
        {
            // Фильтруем ключ, оставляя только русские буквы
            string filteredKey = FilterRussianLetters(key);

            // Если после фильтрации ключ пуст, возвращаем null (ошибка)
            if (string.IsNullOrEmpty(filteredKey))
            {
                return null;
            }

            return filteredKey.ToUpper();
        }
        private void WriteResultToFile(string result)
        {
            if (string.IsNullOrEmpty(outputFilePath))
            {
                MessageBox.Show("Файл для записи не выбран.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                File.WriteAllText(outputFilePath, result); 
                MessageBox.Show("Результат успешно записан в файл: " + outputFilePath, "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при записи в файл: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Key_to_use_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void file_to_write_Click_1(object sender, EventArgs e)
        {
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                outputFilePath = saveFileDialog.FileName;
                MessageBox.Show("Файл для записи выбран: " + outputFilePath, "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        private void file_to_read_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                inputFilePath = openFileDialog.FileName; 
                ReadFile(); 
            }
        }

        private void ReadFile()
        {
            if (!string.IsNullOrEmpty(inputFilePath) && File.Exists(inputFilePath))
            {
                string content = File.ReadAllText(inputFilePath);
                Start.Text = FilterRussianLetters(content).ToUpper();
            }
            else
            {
                MessageBox.Show("Файл для чтения не выбран или не существует.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        
    }
}
