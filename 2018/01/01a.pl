use strict;
use warnings;

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
  my @input = @{$refInput};
  
  my $result = 0;
  
  foreach (@input){
	$result += $_;
  }

  return $result;
}

print(
	getResultingFrequency(
	  getFileContent(
	    "input.txt"
	    )
	  )
	);