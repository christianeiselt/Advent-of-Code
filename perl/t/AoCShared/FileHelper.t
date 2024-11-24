use strict;
use warnings;
use Test::More;
use lib 'perl/lib';
use AoCShared::FileHelper;

# Test if get_input_file retrieves the correct file path for the input file
subtest 'get_input_file retrieves the correct input file' => sub {
    my $file = AoCShared::FileHelper::get_input_file(year => 2018, day => 1);
    my $expected = '_puzzle_inputs_answers/2018/day01_input.txt';
    is($file, $expected, "Input file path is correct for 2018, day 1");
};

# Test if get_example_file retrieves the correct file path for the example input file
subtest 'get_example_file retrieves the correct example file' => sub {
    my $file = AoCShared::FileHelper::get_example_file(year => 2018, day => 1, suffix => 'c', part => 1);
    my $expected = '_puzzle_inputs_answers/2018/day01_part1_example_c_input.txt';
    is($file, $expected, "Example file path is correct for 2018, day 1, part 1, example 'c'");
};

# Test if get_answer_file retrieves the correct answer for part 1
subtest 'get_answer_file retrieves the correct answer file' => sub {
    my $answer = AoCShared::FileHelper::get_answer_file(year => 2018, day => 1, part => 1);
    my $expected_answer = '490';  # Example answer, adjust to your actual answer
    is($answer, $expected_answer, "Answer file content is correct for 2018, day 1, part 1");
};

# Test if get_example_answer_file retrieves the correct example answer for part 1, example 'c'
subtest 'get_example_answer_file retrieves the correct example answer file' => sub {
    my $answer = AoCShared::FileHelper::get_answer_file(year => 2018, day => 1, suffix => 'c', part => 1);
    my $expected_answer = '-6';  # Example answer, adjust to your actual answer
    is($answer, $expected_answer, "Example answer file content is correct for 2018, day 1, part 1, example 'c'");
};

# Test if get_input_file throws an error if file does not exist
subtest 'get_input_file throws error when file does not exist' => sub {
    eval {
        AoCShared::FileHelper::get_input_file(year => 2099, day => 99);
    };
    like($@, qr/input file for 2099 day 99 not found/, 'Throws file not found error for non-existing input file');
};

# Test if get_example_file throws an error if suffix is missing for example file
subtest 'get_example_file throws error when suffix is missing' => sub {
    eval {
        AoCShared::FileHelper::get_example_file(year => 2018, day => 1);
    };
    like($@, qr/Suffix is required for example files/, 'Throws error for missing suffix in example file');
};

# Test if get_answer_file throws an error if the file does not exist for the answer file
subtest 'get_answer_file throws error when file does not exist' => sub {
    eval {
        AoCShared::FileHelper::get_answer_file(year => 2099, day => 99, part => 1);
    };
    like($@, qr/answer file for 2099 day 99 not found/, 'Throws file not found error for non-existing answer file');
};

done_testing();
