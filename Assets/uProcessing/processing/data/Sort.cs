namespace processing.data
{
	public abstract class Runnable {
	}

	/// <summary>
	/// Internal sorter used by several data classes.
	/// Advanced users only, not official API.
	/// </summary>
	public abstract class Sort : Runnable
	{

	  public Sort()
	  {
	  }


	  public virtual void run()
	  {
		int c = size();
		if (c > 1)
		{
		  sort(0, c - 1);
		}
	  }


	  protected internal virtual void sort(int i, int j)
	  {
		int pivotIndex = (i + j) / 2;
		swap(pivotIndex, j);
		int k = partition(i - 1, j);
		swap(k, j);
		if ((k - i) > 1)
		{
			sort(i, k - 1);
		}
		if ((j - k) > 1)
		{
			sort(k + 1, j);
		}
	  }


	  protected internal virtual int partition(int left, int right)
	  {
		int pivot = right;
		do
		{
		  while (compare(++left, pivot) < 0);
		  while ((right != 0) && (compare(--right, pivot) > 0));
		  swap(left, right);
		} while (left < right);
		swap(left, right);
		return left;
	  }


	  public abstract int size();
	  public abstract float compare(int a, int b);
	  public abstract void swap(int a, int b);
	}
}