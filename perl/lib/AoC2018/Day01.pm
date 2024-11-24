package AoC2018::Day01;

use strict;
use warnings;
use Exporter 'import';
use lib 'perl/lib';
use AoCShared::InputHelper;

our @EXPORT_OK = qw(get_resulting_frequency get_first_duplicate process_file);

# Calculate the resulting frequency after summing all changes
sub get_resulting_frequency {
    my ($ref_input) = @_;
    my $resulting_frequency = 0;

    $resulting_frequency += $_ for @{$ref_input};
    return $resulting_frequency;
}

# Find the first frequency that is reached twice
sub get_first_duplicate {
    my ($ref_input) = @_;
    my @changes = @{$ref_input};

    my %frequencies;
    my $current_frequency = 0;

    while (1) {
        for my $change (@changes) {
            $current_frequency += $change;
            return $current_frequency if exists $frequencies{$current_frequency};
            $frequencies{$current_frequency} = 1;
        }
    }
}

# High-level function to process a file and return both results
sub process_file {
    my ($file) = @_;
    my $input = read_file_content($file);

    return (
        get_resulting_frequency($input),
        get_first_duplicate($input),
    );
}

1;
