use strict;
use warnings;
use Data::Dumper;

sub getFileContent
{
    my $file = shift;
    my @output;

    open(my $fh, '<:encoding(UTF-8)', $file)
    or die "Could not open file '$file' $!";

    while (my $row = <$fh>)
    {
        chomp $row;
        $row =~ s/^\+//msx;
        my $number = $row;
        push(@output, $number);
    }

    close($fh);

    return \@output;
}

sub getPrograms {
    my $input = shift;
    my @programs;

    foreach (@{$input}) {
        if($_ ne '') {
            @programs = split(",",$_);
        }
    }
    return \@programs;
}

sub getProgramCodes {
    my $input = shift;
    my @programCodes;
    my $i = 0;

    foreach (@{$input}) {
        if ($_ != 99) {
            push(@{$programCodes[$i]}, $_);
        } else {
            push(@{$programCodes[$i]}, $_);
            $i++;
        }
    }
    return \@programCodes;
}

sub runProgram {
    my $inputRef = shift;
    my @program = @{$inputRef};

    foreach my $ref (@program) {
        my @programCode = @{$ref};
        foreach my $i (@programCode) {
            if ($i != 99) {
                if ($i == 1) {
                    $programCode[$programCode[$i+3]] = $programCode[$programCode[$i+1]] + $programCode[$programCode[$i+2]];
                } elsif ($i == 2) {
                    $programCode[$programCode[$i+3]] = $programCode[$programCode[$i+1]] * $programCode[$programCode[$i+2]];
                }
            } else {
                return \@programCode;
            }
        }
    }

    # print(Dumper(@program));
    return;
}

sub runPrograms {
    my $inputRef = shift;
    my @programCodes = @{$inputRef};

    foreach (@programCodes) {
        runProgram($_);
    }

    return;
}

# my $fileContent = getFileContent("_puzzle_inputs_answers/2019/Day02_input.txt");
# my $programs = getPrograms($fileContent);
# my $programCodes = getProgramCodes($programs);
# my $programResult = runPrograms($programCodes);

my @testA1 = [1,0,0,0,99];
my @testA2 = [2,3,0,3,99];
my @testA3 = [2,4,4,5,99,0];
my @testA4 = [1,1,1,4,99,5,6,0,99];

print(@{runProgram(\@testA1)}." = 2,0,0,0,99\n");

# 1,0,0,0,99 becomes 2,0,0,0,99 (1 + 1 = 2).
# 2,3,0,3,99 becomes 2,3,0,6,99 (3 * 2 = 6).
# 2,4,4,5,99,0 becomes 2,4,4,5,99,9801 (99 * 99 = 9801).
# 1,1,1,4,99,5,6,0,99 becomes 30,1,1,4,2,5,6,0,99.