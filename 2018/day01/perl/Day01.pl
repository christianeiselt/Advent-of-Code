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
    $row =~ s/^\+//;
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
}

print("Resulting Frequency; ".getResultingFrequency(getFileContent("2018/Day01/input.txt"))."\n");
print("Duplicate found: ".getDuplicate(getFileContent("2018/Day01/input.txt"))."\n");