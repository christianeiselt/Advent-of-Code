# https://adventofcode.com/2018/day/1

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

sub getResultingFrequency
{
  my $refInput = shift;
  my @changes = @{$refInput};

  my $resultingFrequency = 0;

  foreach (@changes){
	$resultingFrequency += $_;
  }

  return $resultingFrequency;
}

sub getDuplicate
{
	my $refInput = shift;
	my @changes = @{$refInput};

	my %frequencies;
	my $currentFrequency;
	my $loop;

	while(1){
		$loop++;
		for my $change (@changes){
			$currentFrequency += $change;
			unless($frequencies{$currentFrequency}){
				$frequencies{$currentFrequency} = $currentFrequency;
			} else {
				return ($currentFrequency);
			}
		}
	}

  return;
}

print("The resulting frequency after 1 loop is; ".getResultingFrequency(getFileContent("_puzzle_inputs_answers/2018/day01_input.txt"))."\n");
print("The first frequency reached twice is: ".getDuplicate(getFileContent("_puzzle_inputs_answers/2018/day01_input.txt"))."\n");