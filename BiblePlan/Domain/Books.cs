﻿namespace BiblePlan.Domain
{
    public static class Books
    {
        public static List<string> BookTitles = new List<string> { "Genesis", "Exodus", "Leviticus", "Numbers", "Deuteronomy", "Joshua", "Judges", "Ruth", "1 Samuel", "2 Samuel", "1 Kings", "2 Kings", "1 Chronicles", "2 Chronicles", "Ezra", "Nehemiah", "Esther", "Job", "Psalms", "Proverbs", "Ecclesiastes", "Song of Solomon", "Isaiah", "Jeremiah", "Lamentations", "Ezekiel", "Daniel", "Hosea", "Joel", "Amos", "Obadiah", "Jonah", "Micah", "Nahum", "Habakkuk", "Zephaniah", "Haggai", "Zechariah", "Malachi", "Matthew", "Mark", "Luke", "John", "Acts", "Romans", "1 Corinthians", "2 Corinthians", "Galatians", "Ephesians", "Philippians", "Colossians", "1 Thessalonians", "2 Thessalonians", "1 Timothy", "2 Timothy", "Titus", "Philemon", "Hebrews", "James", "1 Peter", "2 Peter", "1 John", "2 John", "3 John", "Jude", "Revelation" };

        public static List<string> OldTestament = new List<string> { "Genesis", "Exodus", "Leviticus", "Numbers", "Deuteronomy", "Joshua", "Judges", "Ruth", "1 Samuel", "2 Samuel", "1 Kings", "2 Kings", "1 Chronicles", "2 Chronicles", "Ezra", "Nehemiah", "Esther", "Job", "Psalms", "Proverbs", "Ecclesiastes", "Song of Solomon", "Isaiah", "Jeremiah", "Lamentations", "Ezekiel", "Daniel", "Hosea", "Joel", "Amos", "Obadiah", "Jonah", "Micah", "Nahum", "Habakkuk", "Zephaniah", "Haggai", "Zechariah", "Malachi" };

        public static List<string> NewTestament = new List<string> { "Matthew", "Mark", "Luke", "John", "Acts", "Romans", "1 Corinthians", "2 Corinthians", "Galatians", "Ephesians", "Philippians", "Colossians", "1 Thessalonians", "2 Thessalonians", "1 Timothy", "2 Timothy", "Titus", "Philemon", "Hebrews", "James", "1 Peter", "2 Peter", "1 John", "2 John", "3 John", "Jude", "Revelation" };

        public static Dictionary<string, int> BooksWithNumberOfChapters = new Dictionary<string, int>()
        {
            { "Genesis", 50 },
            { "Exodus", 40 },
            { "Leviticus", 27 },
            { "Numbers", 36 },
            { "Deuteronomy", 34 },
            { "Joshua", 24 },
            { "Judges", 21 },
            { "Ruth", 4 },
            { "1 Samuel", 31 },
            { "2 Samuel", 24 },
            { "1 Kings", 22 },
            { "2 Kings", 25 },
            { "1 Chronicles", 29 },
            { "2 Chronicles", 36 },
            { "Ezra", 10 },
            { "Nehemiah", 13 },
            { "Esther", 10 },
            { "Job", 42 },
            { "Psalms", 150 },
            { "Proverbs", 31 },
            { "Ecclesiastes", 12 },
            { "Song of Solomon", 8 },
            { "Isaiah", 66 },
            { "Jeremiah", 52 },
            { "Lamentations", 5 },
            { "Ezekiel", 48 },
            { "Daniel", 12 },
            { "Hosea", 14 },
            { "Joel", 3 },
            { "Amos", 9 },
            { "Obadiah", 1 },
            { "Jonah", 4 },
            { "Micah", 7 },
            { "Nahum", 3 },
            { "Habakkuk", 3 },
            { "Zephaniah", 3 },
            { "Haggai", 2 },
            { "Zechariah", 14 },
            { "Malachi", 4 },
            { "Matthew", 28 },
            { "Mark", 16 },
            { "Luke", 24 },
            { "John", 21 },
            { "Acts", 28 },
            { "Romans", 16 },
            { "1 Corinthians", 16 },
            { "2 Corinthians", 13 },
            { "Galatians", 6 },
            { "Ephesians", 6 },
            { "Philippians", 4 },
            { "Colossians", 4 },
            { "1 Thessalonians", 5 },
            { "2 Thessalonians", 3 },
            { "1 Timothy", 6 },
            { "2 Timothy", 4 },
            { "Titus", 3 },
            { "Philemon", 1 },
            { "Hebrews", 13 },
            { "James", 5 },
            { "1 Peter", 5 },
            { "2 Peter", 3 },
            { "1 John", 5 },
            { "2 John", 1 },
            { "3 John", 1 },
            { "Jude", 1 },
            { "Revelation", 22 }
        };

        public static Dictionary<string, List<int>> BooksWithChapterWordCounts = new Dictionary<string, List<int>>()
        {
            { "Genesis", new List<int>() { 797, 632, 695, 632, 505, 579, 584, 586, 658, 496, 606, 536, 457, 606, 471, 412, 679, 867, 1108, 498, 775, 629, 539, 1816, 706, 889, 1262, 621, 829, 1022, 1417, 794, 508, 790, 664, 845, 942, 819, 666, 580, 1404, 977, 938, 874, 731, 766, 965, 639, 766, 687 } },
            { "Exodus", new List<int>() { 457, 657, 791, 891, 594, 753, 692, 936, 982, 899, 325, 1493, 675, 931, 713, 1062, 465, 760, 702, 561, 893, 790, 827, 492, 926, 937, 558, 1235, 1341, 970, 438, 1092, 710, 1003, 820, 892, 738, 831, 1030, 821 } },
            { "Leviticus", new List<int>() { 525, 486, 511, 1157, 723, 892, 1056, 988, 624, 628, 1115, 262, 1857, 1713, 919, 1157, 553, 667, 898, 836, 587, 880, 1222, 551, 1531, 1246, 956 } },
            { "Numbers", new List<int>() { 1333, 828, 1291, 1416, 898, 742, 1939, 687, 722, 891, 1056, 384, 741, 1180, 1069, 1341, 335, 1111, 683, 791, 931, 1201, 743, 659, 445, 1446, 610, 779, 954, 503, 1208, 1009, 927, 630, 965, 445 } },
            { "Deuteronomy", new List<int>() { 1262, 1021, 815, 1503, 921, 643, 843, 566, 963, 604, 950, 1055, 627, 707, 707, 710, 707, 611, 608, 646, 731, 894, 685, 681, 562, 667, 599, 2075, 851, 665, 1041, 1306, 805, 320 } },
            { "Joshua", new List<int>() { 573, 768, 566, 706, 550, 904, 926, 1221, 800, 1393, 717, 486, 825, 485, 1032, 253, 660, 770, 944, 308, 1026, 1321, 574, 1044 } },
            { "Judges", new List<int>() { 962, 692, 842, 761, 755, 1295, 952, 987, 1667, 473, 1235, 399, 765, 706, 648, 1110, 385, 1035, 1102, 1455, 740 } },
            { "Ruth", new List<int>() { 649, 763, 541, 621 } },
            { "1 Samuel", new List<int>() { 782, 1104, 549, 733, 439, 752, 510, 541, 990, 862, 503, 771, 697, 1606, 981, 680, 1719, 845, 696, 1289, 499, 761, 831, 661, 1452, 849, 385, 835, 421, 956, 348 } },
            { "2 Samuel", new List<int>() { 712, 911, 1143, 434, 624, 713, 858, 447, 408, 608, 814, 992, 1148, 1117, 1118, 738, 935, 1096, 1473, 848, 778, 951, 878, 855 } },
            { "1 Kings", new List<int>() { 1499, 1510, 850, 706, 527, 1018, 1482, 2139, 826, 839, 1253, 1038, 1138, 987, 951, 1035, 680, 1397, 732, 1480, 908, 1517 } },
            { "2 Kings", new List<int>() { 669, 848, 848, 1368, 975, 1019, 824, 954, 1205, 1203, 738, 688, 775, 881, 1092, 656, 1245, 1221, 1148, 660, 747, 712, 1477, 584, 982 } },
            { "1 Chronicles", new List<int>() { 683, 846, 347, 852, 664, 1341, 831, 491, 960, 364, 944, 987, 386, 357, 714, 850, 779, 399, 630, 289, 914, 605, 681, 541, 543, 710, 805, 864, 988 } },
            { "2 Chronicles", new List<int>() { 530, 645, 481, 595, 497, 1402, 748, 536, 882, 559, 486, 481, 642, 448, 518, 479, 459, 1051, 352, 1148, 623, 444, 788, 933, 970, 721, 244, 896, 1157, 869, 757, 1084, 780, 1223, 900, 741 } },
            { "Ezra", new List<int>() { 371, 998, 547, 769, 583, 778, 863, 990, 617, 924 } },
            { "Nehemiah", new List<int>() { 390, 718, 896, 716, 636, 602, 1176, 686, 1328, 652, 788, 930, 962 } },
            { "Esther", new List<int>() { 716, 806, 552, 517, 494, 476, 343, 649, 984, 93 } },
            { "Job", new List<int>() { 641, 387, 434, 336, 447, 482, 394, 340, 544, 402, 337, 399, 413, 410, 549, 375, 262, 342, 475, 521, 522, 482, 280, 481, 90, 206, 373, 455, 404, 514, 691, 375, 524, 615, 254, 495, 402, 659, 477, 361, 507, 441 } },
            { "Psalms", new List<int>() { 130, 206, 139, 165, 245, 159, 327, 166, 367, 350, 128, 147, 107, 149, 99, 206, 311, 918, 272, 144, 246, 581, 118, 178, 342, 183, 340, 201, 179, 231, 498, 241, 350, 347, 564, 223, 702, 361, 270, 400, 240, 281, 130, 451, 327, 204, 143, 229, 337, 400, 322, 165, 152, 110, 435, 225, 230, 218, 339, 211, 133, 228, 194, 184, 267, 327, 111, 698, 670, 102, 471, 369, 423, 413, 189, 193, 330, 1225, 277, 334, 288, 116, 273, 226, 207, 313, 113, 296, 879, 320, 288, 258, 92, 356, 199, 226, 189, 170, 157, 86, 173, 455, 342, 598, 632, 762, 685, 206, 534, 142, 177, 172, 142, 106, 274, 287, 33, 465, 2423, 88, 110, 124, 94, 121, 108, 94, 110, 101, 119, 116, 60, 276, 69, 44, 329, 353, 165, 172, 410, 239, 203, 151, 252, 302, 331, 178, 299, 202, 143, 85 } },
            { "Proverbs", new List<int>() { 519, 309, 541, 418, 354, 546, 411, 562, 288, 527, 524, 476, 400, 572, 544, 543, 476, 381, 506, 498, 501, 495, 566, 580, 522, 459, 460, 528, 425, 640, 467 } },
            { "Ecclesiastes", new List<int>() { 380, 734, 517, 380, 533, 301, 618, 515, 555, 402, 273, 372 } },
            { "Song of Solomon", new List<int>() { 326, 351, 287, 363, 397, 282, 292, 360 } },
            { "Isaiah", new List<int>() { 758, 568, 587, 210, 863, 366, 693, 558, 599, 928, 519, 134, 576, 856, 266, 415, 428, 255, 730, 169, 417, 675, 469, 592, 381, 550, 405, 814, 742, 1059, 322, 436, 585, 522, 277, 690, 1131, 592, 268, 796, 804, 676, 711, 886, 774, 342, 471, 627, 867, 365, 771, 405, 387, 493, 399, 361, 569, 522, 591, 665, 380, 362, 538, 308, 753, 811 } },
            { "Jeremiah", new List<int>() { 528, 1019, 802, 861, 874, 827, 970, 706, 772, 674, 749, 544, 739, 688, 702, 699, 829, 659, 541, 594, 498, 837, 1186, 361, 1138, 800, 762, 540, 1005, 717, 1294, 1432, 842, 824, 657, 1110, 611, 984, 545, 681, 664, 774, 460, 1228, 152, 821, 215, 1172, 1180, 1460, 1853, 1074 } },
            { "Lamentations", new List<int>() { 758, 883, 876, 598, 296 } },
            { "Ezekiel", new List<int>() { 870, 273, 809, 519, 628, 470, 768, 655, 400, 659, 721, 799, 738, 746, 205, 1820, 773, 919, 356, 1601, 945, 840, 1322, 774, 508, 727, 907, 809, 714, 760, 679, 1077, 1071, 958, 402, 1180, 870, 776, 928, 1530, 802, 568, 907, 1031, 882, 880, 780, 1045 } },
            { "Daniel", new List<int>() { 589, 1500, 992, 1290, 995, 905, 926, 852, 966, 647, 1530, 411 } },
            { "Hosea", new List<int>() { 355, 678, 156, 465, 368, 254, 398, 330, 468, 425, 308, 311, 426, 232 } },
            { "Joel", new List<int>() { 508, 957, 568 } },
            { "Amos", new List<int>() { 455, 441, 397, 432, 658, 399, 471, 414, 549 } },
            { "Obadiah", new List<int>() { 669 } },
            { "Jonah", new List<int>() { 514, 214, 260, 332 } },
            { "Micah", new List<int>() { 452, 400, 354, 476, 447, 440, 583 } },
            { "Nahum", new List<int>() { 394, 371, 519 } },
            { "Habakkuk", new List<int>() { 423, 563, 489 } },
            { "Zephaniah", new List<int>() { 556, 463, 598 } },
            { "Haggai", new List<int>() { 451, 679 } },
            { "Zechariah", new List<int>() { 622, 317, 296, 365, 338, 424, 378, 703, 537, 408, 502, 462, 337, 754 } },
            { "Malachi", new List<int>() { 487, 546, 565, 183 } },
            { "Matthew", new List<int>() { 473, 619, 387, 557, 1081, 794, 626, 773, 837, 919, 668, 1168, 1367, 721, 785, 688, 620, 869, 719, 779, 1126, 828, 833, 1047, 995, 1625, 1359, 421 } },
            { "Mark", new List<int>() { 930, 724, 663, 923, 952, 1323, 806, 842, 1164, 1218, 778, 1058, 828, 1595, 913, 449 } },
            { "Luke", new List<int>() { 1583, 1094, 1017, 1021, 949, 1229, 1209, 1431, 1457, 992, 1331, 1407, 864, 812, 725, 752, 809, 868, 1047, 954, 820, 1396, 1116, 1055 } },
            { "John", new List<int>() { 1004, 510, 763, 1094, 1001, 1506, 1002, 1307, 876, 820, 1157, 1060, 826, 731, 613, 789, 636, 947, 1010, 749, 693 } },
            { "Acts", new List<int>() { 661, 1021, 634, 865, 1026, 355, 1430, 883, 1046, 1108, 667, 662, 1273, 627, 925, 943, 855, 664, 975, 882, 1067, 773, 921, 640, 711, 781, 1033, 818 } },
            { "Romans", new List<int>() { 714, 604, 562, 546, 480, 484, 605, 903, 719, 461, 818, 397, 361, 525, 742, 501 } },
            { "1 Corinthians", new List<int>() { 649, 373, 459, 509, 321, 465, 959, 309, 672, 667, 718, 593, 270, 887, 1166, 446 } },
            { "2 Corinthians", new List<int>() { 591, 401, 389, 406, 487, 358, 452, 568, 355, 437, 718, 589, 315 } },
            { "Galatians", new List<int>() { 453, 573, 648, 610, 447, 353 } },
            { "Ephesians", new List<int>() { 508, 453, 410, 617, 564, 470 } },
            { "Philippians", new List<int>() { 632, 601, 483, 467 } },
            { "Colossians", new List<int>() { 656, 503, 457, 363 } },
            { "1 Thessalonians", new List<int>() { 253, 479, 295, 396, 414 } },
            { "2 Thessalonians", new List<int>() { 291, 381, 350 } },
            { "1 Timothy", new List<int>() { 432, 247, 324, 310, 470, 461 } },
            { "2 Timothy", new List<int>() { 438, 506, 297, 426 } },
            { "Titus", new List<int>() { 337, 265, 294 } },
            { "Philemon", new List<int>() { 430 } },
            { "Hebrews", new List<int>() { 338, 472, 362, 404, 321, 425, 607, 387, 678, 784, 922, 696, 501 } },
            { "James", new List<int>() { 544, 528, 378, 369, 485 } },
            { "1 Peter", new List<int>() { 597, 549, 551, 479, 300 } },
            { "2 Peter", new List<int>() { 488, 581, 484 } },
            { "1 John", new List<int>() { 247, 735, 534, 480, 520 } },
            { "2 John", new List<int>() { 298 } },
            { "3 John", new List<int>() { 294 } },
            { "Jude", new List<int>() { 608 } },
            { "Revelation", new List<int>() { 592, 802, 658, 348, 435, 540, 491, 397, 592, 353, 580, 497, 538, 651, 252, 567, 522, 747, 634, 477, 749, 573 } }
        };
    }
}