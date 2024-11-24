package AoCShared::FileHelper;

use strict;
use warnings;
use File::Spec;
use Carp;

# Base directory for input and answer files
my $base_dir = '_puzzle_inputs_answers';

# Internal subroutine to handle file path creation and validation
sub _get_file {
    my (%args) = @_;

    my $year  = $args{year}  or croak "Year is required";
    my $day   = $args{day}   or croak "Day is required";
    my $type  = $args{type}  or croak "Type (input/answer/example) is required";
    my $part  = $args{part}  // 1;  # Default to part 1 if not provided
    my $suffix = $args{suffix}; # Optional suffix for example files
    
    my $file_name;

    # Construct file name based on parameters
    if ($type eq 'input') {
        # The input file does not contain the part, so no need to add part to the filename
        $file_name = "day" . sprintf("%02d", $day) . "_input.txt";
    }
    elsif ($type eq 'example') {
        if ($suffix) {
            # Example files include part and suffix
            $file_name = "day" . sprintf("%02d", $day) . "_part${part}_example_${suffix}_input.txt";
        } else {
            # Example files require a suffix
            croak "Suffix is required for example files";
        }
    }
    elsif ($type eq 'answer') {
        # Check if it's an answer file or example answer file
        if ($suffix) {
            # Example answer file: e.g., day01_part1_example_c_answer.txt
            $file_name = "day" . sprintf("%02d", $day) . "_part${part}_example_${suffix}_answer.txt";
        } else {
            # General answer file: e.g., day01_part1_answer.txt
            $file_name = "day" . sprintf("%02d", $day) . "_part${part}_answer.txt";
        }
    } else {
        croak "Unknown file type: $type";
    }

    # Construct full file path
    my $file_path = File::Spec->catfile($base_dir, $year, $file_name);
    
    unless (-e $file_path) {
        croak "$type file for $year day $day not found: $file_path";
    }

    # If the file is an answer file, return the content
    if ($type eq 'answer') {
        open my $fh, '<', $file_path or croak "Could not open answer file $file_path: $!";
        chomp(my $answer = <$fh>);
        close $fh;
        return $answer;
    }

    # Return the file path for input or example files
    return $file_path;
}

# Public method to get an input file
sub get_input_file {
    my (%args) = @_;
    return _get_file(%args, type => 'input');
}

# Public method to get an example file
sub get_example_file {
    my (%args) = @_;
    return _get_file(%args, type => 'example');
}

# Public method to get an answer file
sub get_answer_file {
    my (%args) = @_;
    return _get_file(%args, type => 'answer');
}

1;
