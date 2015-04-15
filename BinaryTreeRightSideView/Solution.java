/**
 * Definition for binary tree
 * public class TreeNode {
 *     int val;
 *     TreeNode left;
 *     TreeNode right;
 *     TreeNode(int x) { val = x; }
 * }
 */
public class Solution {
    public List<Integer> rightSideView(TreeNode root) {
			List<Integer> list = new ArrayList<Integer>();
	        if (root != null) {
    	        Integer iMaxLevel = -1;
	            Integer iCurrentLevel = 0;
	            Stack<TreeNode> stack = new Stack<TreeNode>();
	            searchNodes(stack, list, root, iMaxLevel, iCurrentLevel);
	        }
	        return list;
	    }
		
		public Integer searchNodes(Stack<TreeNode> stack, List<Integer> list, TreeNode node, Integer maxLevel, Integer currentLevel){
			if (node != null){
				stack.push(node);
				if (currentLevel > maxLevel){
					list.add(node.val);
					maxLevel = currentLevel;
				}
				
				maxLevel = searchNodes(stack, list, node.right, maxLevel, currentLevel+1);
				maxLevel = searchNodes(stack, list, node.left, maxLevel, currentLevel+1);
				
				stack.pop();				
			}
			return maxLevel;
		}
}

