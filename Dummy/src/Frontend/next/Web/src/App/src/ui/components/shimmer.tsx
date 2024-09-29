import clsx from 'clsx';

interface ShimmerProps extends React.HTMLAttributes<HTMLDivElement> {
  children: React.ReactNode;
}

export function Shimmer({ children, className, ...rest }: ShimmerProps) {
  return (
    <div
      {...rest}
      className={clsx(
        'before:absolute',
        'before:inset-0',
        'before:-translate-x-full',
        'before:animate-[shimmer_2s_infinite]',
        'before:bg-gradient-to-r',
        'before:from-transparent',
        'before:via-white/60',
        'before:to-transparent',
        'relative overflow-hidden',
        className,
      )}
    >
      {children}
    </div>
  );
}