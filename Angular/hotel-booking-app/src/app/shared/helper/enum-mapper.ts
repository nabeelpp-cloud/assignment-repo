export const RoomStatusMap: { [key: number]: string } = {
  0: 'Available',
  1: 'Booked',
  2: 'Under Maintenance',
};

export function getEnumName(map: { [key: number]: string }, value: number): string {
    return map[value] ?? 'Unknown';
  }